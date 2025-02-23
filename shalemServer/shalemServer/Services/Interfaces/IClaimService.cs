using System.Security.Claims;
namespace shalemServer.Services.Interfaces
{
    public interface IClaimService
    {
        void SetClaimsPrincipal(ClaimsPrincipal claimsPrincipal);
        ClaimsPrincipal GetClaimsPrincipal();
        //string GetUserId();
        //string GetUserEmail();
    }
}
