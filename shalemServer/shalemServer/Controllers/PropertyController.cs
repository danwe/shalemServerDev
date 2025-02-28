using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shalemServer.Interfaces;
using shalemServer.Models;
using shalemServer.Models.Dto;

namespace shalemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {



        private readonly ShalemDbDevContext _context;
        private readonly IManaRepository _manaRepository;



        public PropertyController(ShalemDbDevContext context, IManaRepository manaRepository)
        {
            _context = context;
            _manaRepository = manaRepository;
        }

        [HttpPost("password-change")]
        public IActionResult PasswordChange([FromBody] PropertyDto property)
        {
         

            // Simulate sending an email or changing a password
            var response = new ApiResponse<dynamic>
            {
                Success = true,
                Message = "Password changed successfully.",
                Data = "Email sent successfully."
            };

            return Ok(response);
        }

        // Create a DTO (Data Transfer Object) for request data
     
    }
}