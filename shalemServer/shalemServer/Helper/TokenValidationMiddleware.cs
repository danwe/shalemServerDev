using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using shalemServer.Models.custom;
using shalemServer.Models.Dto;
using shalemServer.Services;
using shalemServer.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace shalemServer.Helper
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public ClaimService claimService;


        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Get the Authorization header from the request

            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null)
            {

                // Check if the Authorization header is missing or doesn't start with "Bearer "
                if ((string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer ")) && context.Request.Path.Value.ToLower() != "/api/login/login")
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Unauthorized: Missing or invalid token.");
                    return;
                }

                // Extract the token from the Authorization header
                string token = authHeader.Substring("Bearer ".Length).Trim();

                var claims = TokenDecoder.DecodeToken(token).Claims;
                ClaimService claimService = new ClaimService();
                UserClaims userClaims = new UserClaims();

                userClaims = new UserClaims
                {
                    LastName = claims.FirstOrDefault(c => c.Type == "lastName")?.Value ?? string.Empty,
                    FirstName = claims.FirstOrDefault(c => c.Type == "firstName")?.Value ?? string.Empty,
                    Id = claims.FirstOrDefault(c => c.Type == "id")?.Value ?? string.Empty,

                    Email = claims.FirstOrDefault(c => c.Type == "email")?.Value ?? string.Empty,
                    TimeExpired = int.TryParse(claims.FirstOrDefault(c => c.Type == "timeExpired")?.Value, out var time) ? time : -1,
                    PasswordExpired = bool.TryParse(claims.FirstOrDefault(c => c.Type == "passwordExpired")?.Value, out var isExpired) && isExpired,
                    Message = claims.FirstOrDefault(c => c.Type == "message")?.Value ?? string.Empty
                };
                claimService.SetClaimsPrincipal(userClaims);
                if (claims != null)
                {
                    Console.WriteLine("Decoded claims:");
                    //foreach (var claim in claimsPrincipal.Claims)
                    //{
                    //    Console.WriteLine($"{claim.Type}: {claim.Value}");
                    //}
                }
            }

            

            // Perform token validation here (e.g., JWT validation)

            // If token is valid, proceed to the next middleware
            await _next(context);
        }

      
    }

    // Extension method used to add the middleware to the HTTP request pipeline
    public static class TokenValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenValidationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenValidationMiddleware>();
        }
    }

   

}