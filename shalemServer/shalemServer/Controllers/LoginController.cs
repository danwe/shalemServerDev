using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using shalemServer.Helper;
using shalemServer.Interfaces;
using shalemServer.Models;
using shalemServer.Models.custom;
using shalemServer.Models.Dto;
using shalemServer.Services;
using shalemServer.Services.Interfaces;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shalemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IloginRepository _loginRepository;

        private bool isPasswordExpired = false;
        private string messageExpired = "";
        private AspNetUserDto userReturn;
        public TokenValidationMiddleware tokenValidationMiddleware;
        private readonly ClaimService _claimService;
        private readonly IUserRepository _userRepository;


        public LoginController(IConfiguration configuration, IloginRepository loginRepository , ClaimService claimService, IUserRepository userRepository)
        {
            _configuration = configuration;
            _loginRepository = loginRepository;
            _claimService = claimService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("role")]
        public async Task<ActionResult<object>> role()
        {
            UserClaims userClaims = _claimService.GetClaims();

            var valid = _loginRepository.GetRoles(userClaims.Id);

            var response = new ApiResponse<dynamic>
            {
                Success = true,
                Message = "Email sent successfully",
                Data = "send mail"
            };

            return Ok(new { response });
        }
        [HttpGet("login")]
        public async Task<ActionResult<object>> loginAsync(string user, string password)
        {
            UserClaims userClaims = _claimService.GetClaims();

            var loginResponse = new LoginResponse { };
            LoginRequest loginrequest = new()
            {
                UserName = user.ToLower(),
                Password = password
            };
            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();
            var valid = _loginRepository.ChechValidUserPassordAsync(loginrequest.UserName, loginrequest.Password);
            userReturn = await  _loginRepository.GetUser(loginrequest.UserName, loginrequest.Password);
            bool passwordExpired = false;
            string passwordHash = null;
            string dayExpired = "-1";
            if (userReturn != null) {
                passwordExpired = userReturn.DateUpdatedPassword.HasValue &&
                               userReturn.DateUpdatedPassword.Value.AddDays(60) < DateTime.Now;
                dayExpired =  GetPasswordExpirationStatus(userReturn.DateUpdatedPassword);

                // Access the values
                string key = configuration["EncryptionSettings:Key"];
                string iv = configuration["EncryptionSettings:IV"];
                //var user = await _userServices.GetUser(request.Email);
                //string key = "Your32ByteSecretKeyMustBeHere!!2"; // 32 bytes
                //string iv = "16ByteInitVector";               // 16 bytes

                var service = new EncryptionService(key, iv);

                passwordHash = userReturn.Password.IsNullOrEmpty() ? "" : service.Decrypt(userReturn.Password);
            }


            List<UserRoleDto> role = new List<UserRoleDto>();

            bool isUsernamePasswordValid = true;
            List<PositionDto> positionList = new List<PositionDto>();
            List<UserCityDto> cityUserList = new List<UserCityDto>();

            if (valid != null && !passwordHash.IsNullOrEmpty())
            {
                // make await call to the Database to check username and password. here we only checking if password value is admin
                isUsernamePasswordValid = loginrequest.Password == passwordHash ? true : false;
            }
            //if (userReturn.Password.IsNullOrEmpty())
            //{
            //    isPasswordExpired = passwordExpired;
            //    messageExpired = "first_time";
            //}
            if (valid.Result &&  (userReturn  == null || userReturn.Password.IsNullOrEmpty()))
            {
                isPasswordExpired = passwordExpired;
                messageExpired = "first_time";
            }

            if (isUsernamePasswordValid)
            {
                if (userReturn != null) {
                    positionList = positionList = _userRepository.GetPosition(userReturn.Id);
                    role = _loginRepository.GetRoles(userReturn.Id);
                    cityUserList = _loginRepository.GetUserCities(userReturn.Id);
                }
          
                var untils = new Untils(configuration);
                string token = untils.CreateToken(loginrequest.UserName, userReturn, isPasswordExpired, messageExpired, positionList, role, dayExpired, cityUserList);


                loginResponse.Token = token;
                loginResponse.responseMsg = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };
            

                //return the token
                return Ok(new { loginResponse });
            }
            else
            {
                return BadRequest("Username or Password Invalid!");
            }
        }

        string GetPasswordExpirationStatus(DateTime? dateUpdatedPassword)
        {
            if (dateUpdatedPassword.HasValue)
            {
                DateTime expirationDate = dateUpdatedPassword.Value.AddDays(60);
                TimeSpan timeDifference = expirationDate - DateTime.Now;

                if (timeDifference.TotalSeconds > 0)
                {
                    return timeDifference.Days.ToString();
                }
                else
                {
                    return $"-1";
                }
            }
            else
            {
                return "Password update date is not set.";
            }
        }
    }
}

