using System.ComponentModel.DataAnnotations;

namespace shalemServer.Models.custom
{
    public class ChangePasswordWithTokenRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The new password must be at least 6 characters long.")]
        public string NewPassword { get; set; }
    }
}
