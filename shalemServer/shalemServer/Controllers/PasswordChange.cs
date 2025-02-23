namespace shalemServer.Controllers
{
    public class PasswordChange
    {
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }

        public PasswordChange(string oldPassword, string newPassword, string confirmPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }

        // Parameterless constructor for serialization/deserialization purposes
        public PasswordChange() { }
    }
}