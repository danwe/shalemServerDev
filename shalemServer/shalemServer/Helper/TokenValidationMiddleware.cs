using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace shalemServer.Helper
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

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
                var claimsPrincipal = TokenDecoder.DecodeToken(token);
                
                if (claimsPrincipal != null)
                {
                    Console.WriteLine("Decoded claims:");
                    foreach (var claim in claimsPrincipal.Claims)
                    {
                        Console.WriteLine($"{claim.Type}: {claim.Value}");
                    }
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