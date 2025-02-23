using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shalemServer.Helper;
using shalemServer.Interfaces;
using shalemServer.Models;
using shalemServer.Models.custom;
using shalemServer.Services.Interfaces;
using System.Configuration;

namespace shalemServer.Controllers
{


 
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly string key;
        private readonly string iv;
        private readonly IEmailService _emailService;
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;


        public PasswordResetController(IConfiguration configuration, IEmailService emailService, IUserServices userServices)
        {
            _emailService = emailService;
            _userServices = userServices;

        }

        [HttpPost("sendMail")]

        public async Task<ActionResult<dynamic>> SendToMail([FromBody] EmailRequest request)
        {
    //        await _emailService.SendEmailAsync(request.Email, request.Subject, request.Body);

            var response = new ApiResponse<dynamic>
            {
                Success = true,
                Message = "Email sent successfully",
                Data = "send mail"
            };

            return Ok(response);
        }

        [HttpPost("changePassword")]
        public async Task<ActionResult<dynamic>> changePassword([FromBody] EmailRequest request)
        {
            //        await _emailService.SendEmailAsync(request.Email, request.Subject, request.Body);

            var response = new ApiResponse<dynamic>
            {
                Success = true,
                Message = "Email sent successfully",
                Data = "send mail"
            };

            return Ok(response);
        }

        [HttpPost("request-change-password")]
        public async Task<IActionResult> RequestChangePassword([FromBody] PasswordResetRequest request)
        {
            var user = await _userServices.GetUser(request.Email);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            // Generate a password reset token
            //var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Send the token via email (replace this with your email service)
            await _emailService.SendEmailAsync(user.Email, "Password Reset Token", $"Your reset token: ''");

            return Ok(new { Message = "Reset token sent to email." });
        }

        [HttpPost("change-password-with-token")]
        public async Task<IActionResult> ChangePasswordWithToken([FromBody] ChangePasswordWithTokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .Build();

            // Access the values
            string key = configuration["EncryptionSettings:Key"];
            string iv = configuration["EncryptionSettings:IV"];
            var user = await _userServices.GetUser(request.Email);
            //string key = "Your32ByteSecretKeyMustBeHere!!2"; // 32 bytes
            //string iv = "16ByteInitVector";               // 16 bytes

            var service = new EncryptionService(key, iv);
            //var service = new EncryptionService();

            string encrypted = service.Encrypt(request.NewPassword);
            Console.WriteLine($"Encrypted: {encrypted}");

            string decrypted = service.Decrypt(encrypted);
                    Console.WriteLine($"Decrypted: {decrypted}");

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            // Verify the token and reset the password
           // var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

            //if (!result.Succeeded)
            //{
            //    return BadRequest(result.Errors);
            //}

            return Ok(new { Message = "Password changed successfully." });
        }

        [HttpPost("password-change")]
        public IActionResult passwordChange([FromBody] PasswordChangeRequest passwordChange)
        {
            // Check if the request object is null
            if (passwordChange == null)
            {
                return BadRequest("Invalid request.");
            }

            // Retrieve the user from the database using the email
            // var user = await _userManager.FindByEmailAsync(request.Email);

            // If the user is not found, return an error message
            //if (user == null)
            //{
            //    return BadRequest("User not found.");
            //}

            // Verify the token provided by the user
            //var isValidToken = await _userManager.VerifyUserTokenAsync(
            //    user,
            //    _userManager.Options.Tokens.PasswordResetTokenProvider,
            //    "ResetPassword",
            //    request.Token);

            // If the token is not valid, return an error message
            //if (!isValidToken)
            //{
            //    return BadRequest("Invalid or expired token.");
            //}

            //// Proceed to reset the password
            ///

            var userId = HttpContext.Session.GetString("UserId");
            var keys = HttpContext.Session.Keys;

            var result = _userServices.ChangePassword(passwordChange); 

            // If the password reset fails, return the errors
            //if (!result.Succeeded)
            //{
            //    return BadRequest(result.Errors);
            //}

            // If successful, return a success message
            var response = new ApiResponse<dynamic>
            {
                Success = true,
                Message = "Password changed successfully.",
                Data = "send mail"
            };
            return Ok(response);
        }
     

        [HttpGet("SendEmailResetPassword")]
        public async Task<IActionResult> SendEmailResetPassword(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userServices.GetUser(email);
            //TODO send to mail with  

            //if (user == null)
            //{
            //    return BadRequest("User not found.");
            //}

            // Verify the token and reset the password
            // var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

            //if (!result.Succeeded)
            //{
            //    return BadRequest(result.Errors);
            //}
            var response = new ApiResponse<dynamic>
            {
                Success = user != null ? true : false,
                Message = user != null ? "mail true" : "mail no found",
                Data = "send mail"
            };
            return Ok(response);
        }
    }
}
