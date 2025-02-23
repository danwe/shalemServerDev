using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using shalemServer.Interfaces;
using shalemServer.Models.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace shalemServer.Helper
{
    public class Untils
    {
        private readonly IConfiguration _configuration;
        public Untils(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static string MaskEmail(string email)
        {
            var parts = email.Split('@');
            if (parts.Length == 2)
            {
                var localPart = parts[0];
                var domain = parts[1];

                // Mask the local part (the part before the '@')
                var maskedLocalPart = localPart.Substring(0, 2) + "xxx";  // Keep first two characters, mask the rest
                var maskedDomain = domain.Substring(0, 1) + "xxx" + domain.Substring(domain.IndexOf('.'));

                return $"{maskedLocalPart}@{maskedDomain}";
            }

            return email;  // Return the original email if it's not valid
        }

        public string CreateToken(string username, AspNetUserDto userReturn, bool isPasswordExpired, string messageExpired, List<PositionDto> positionList,
            List<UserRoleDto> roles, string dayExpired, List<UserCityDto> cityUserList)
        {
            var rolesJson = JsonConvert.SerializeObject(roles);
            var positionListJson = JsonConvert.SerializeObject(positionList);
            var cityUserListJson = JsonConvert.SerializeObject(cityUserList);

            List<Claim> claims = new()
            {               
                
                //list of Claims - we only checking username - more claims can be added.
                new Claim("lastName", Convert.ToString(userReturn == null ? "null" : userReturn.LastName)),
                new Claim("firstName", Convert.ToString(userReturn == null ? "null" : userReturn.FirstName)),
                new Claim("email", Convert.ToString(MaskEmail(userReturn == null ? "null" : userReturn.Email))),
                new Claim("id", Convert.ToString(userReturn == null ? "null" :  userReturn.Id)),
                new Claim("timeExpired", dayExpired),
                new Claim("roles", rolesJson),
                new Claim("positionList", positionListJson),
                new Claim("passwordExpired", isPasswordExpired.ToString()), // Adds password expiration status
                new Claim("message", messageExpired), // Adds a custom message
                 new Claim("cityUserList", cityUserListJson) // Adds a custom message
 

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSetting:Key").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        internal string CreateToken(string userName, AspNetUserDto? userReturn, bool isPasswordExpired, string messageExpired, List<PositionDto> positionList, List<UserRoleDto> role, object dayExpired)
        {
            throw new NotImplementedException();
        }
    }


}
