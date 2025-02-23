using shalemServer.Models.custom;


namespace shalemServer.Services
{
    public class ClaimService
    {
        private static UserClaims _userClaims = new UserClaims(); // Initialize to prevent null issues

        public void SetClaimsPrincipal(UserClaims userClaims)
        {
            if (userClaims == null)
            {
                throw new ArgumentNullException(nameof(userClaims), "UserClaims cannot be null.");
            }

            _userClaims = userClaims;
        }

        public UserClaims GetClaims()
        {
            // Return a default UserClaims object if _userClaims is null
            return _userClaims;
        }

    }
}
