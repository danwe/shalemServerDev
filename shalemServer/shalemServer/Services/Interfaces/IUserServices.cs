using shalemServer.Controllers;
using shalemServer.Models.custom;
using shalemServer.Models.Dto;
using static shalemServer.Controllers.PasswordResetController;

namespace shalemServer.Services.Interfaces
{
    public interface IUserServices
    {
        public Task<AspNetUserDto> GetUser(string user);
        public bool ChangePassword(PasswordChangeRequest passwordChange);
    }
}
