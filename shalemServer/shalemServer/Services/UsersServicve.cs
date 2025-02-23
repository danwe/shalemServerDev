using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shalemServer.Controllers;
using shalemServer.Interfaces;
using shalemServer.Models;
using shalemServer.Models.custom;
using shalemServer.Models.Dto;
using shalemServer.Services.Interfaces;

namespace shalemServer.Services
{
    public class UsersServicve : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly ShalemDbDevContext _context;

        private readonly IMapper _mapper;
        private readonly ClaimService _claimService;

        public UsersServicve(ShalemDbDevContext context, IUserRepository userRepository, IMapper mapper, ClaimService claimService)
        {
           
            _context = context;
            _userRepository = userRepository;
            _mapper = mapper;
            _claimService = claimService ?? throw new ArgumentNullException(nameof(claimService));


        }

        public bool ChangePassword(PasswordChangeRequest passwordChange)
        {
            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            string key = configuration["EncryptionSettings:Key"];
            string iv = configuration["EncryptionSettings:IV"];
            //string key = "Your32ByteSecretKeyMustBeHere!!2"; // 32 bytes
            //string iv = "16ByteInitVector";               // 16 bytes

            var service = new EncryptionService(key, iv);
            //var service = new EncryptionService();

            string passwordNewHash = service.Encrypt(passwordChange.NewPassword);
            UserClaims userClaims = _claimService.GetClaims();
            // Retrieve user list based on userName and email
            return _userRepository.UpdatePassword(userClaims.Id, passwordNewHash);
        }

        public async Task<AspNetUserDto> GetUser(string user)
        {
            string userName = null;
            string email = user;
            bool? isActive = null;

            // Retrieve user list based on userName and email
            var aspNetUser = await _userRepository.GetTopUsersAsync(userName, email);

            if (aspNetUser == null || !aspNetUser.Any())
            {
                throw new Exception($"User with email {email} not found.");
            }

            // var userEntity = aspNetUser.ToList();
            var userEntity = _mapper.Map<AspNetUserDto>(
                aspNetUser
                    .Where(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault()
            );
            //var passwordHasher = new PasswordHasher<AspNetUserDto>();

            //var verificationResult = passwordHasher.VerifyHashedPassword(userEntity, userEntity.PasswordHash, password);
            //if (userEntity.Password.IsNullOrEmpty())
            //{ 

            //}

            //if (verificationResult == PasswordVerificationResult.Failed)
            //{
            //    throw new Exception("Invalid password.");
            //}

            return userEntity;
        }
    }
}
