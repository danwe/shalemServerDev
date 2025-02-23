namespace shalemServer.Models.custom
{
    public class UserClaims
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Id { get; set; }

        public string Email { get; set; }
        public int TimeExpired { get; set; }
        public bool PasswordExpired { get; set; }
        public string Message { get; set; }
    }
}
