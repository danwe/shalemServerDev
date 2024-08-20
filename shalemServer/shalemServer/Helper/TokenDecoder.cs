using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace shalemServer.Helper
{
    public class TokenDecoder
    {
        public static ClaimsPrincipal DecodeToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                return new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims, "jwt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error decoding token: {ex.Message}");
                return null;
            }
        }
    }
}
