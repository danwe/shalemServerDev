using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using shalemServer.Interfaces;
using shalemServer.Models;
using shalemServer.Models.Dto;

namespace shalemServer.Repository
{
    public class LoginRepository : IloginRepository
    {
        private readonly ShalemDbDevContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginRepository(ShalemDbDevContext context, IUserRepository userRepository, IMapper mapper)
        {
            _context = context;
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task<bool> ChechValidUserPassordAsync(string user, string password)
        {
            string email = "danweill0@gmail.com";
            // Use StringComparison.OrdinalIgnoreCase for case-insensitive comparison

            //if (aspNetUser == null)
            //{
            //    throw new Exception($"User with email {email} not found.");
            //}
            var passwordHasher = new PasswordHasher<AspNetUser>();
            // var verificationResult = passwordHasher.VerifyHashedPassword(aspNetUser[0], user, password);
            return true;
        }

        public List<UserRoleDto> GetRoles(string userId)
        {
            return _userRepository.GetRoles(userId);
        }
        public List<UserCityDto> GetUserCities(string userId)
        {
            return _userRepository.GetUserCities(userId);
        }
        

        public async Task<AspNetUserDto> GetUser(string user, string password)
        {
            string userName = user;
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
            var passwordHasher = new PasswordHasher<AspNetUserDto>();

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
