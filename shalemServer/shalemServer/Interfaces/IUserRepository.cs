using shalemServer.Models.Dto;
using static shalemServer.Controllers.PasswordResetController;

namespace shalemServer.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AspNetUserDto>> GetTopUsersAsync(
              string userName = null,
              string email = null,
              bool? isActive = null,
              bool? emailConfirmed = null,
              bool? phoneNumberConfirmed = null,
              bool? twoFactorEnabled = null,
              DateTime? dateCreatedFrom = null,
              DateTime? dateCreatedTo = null
          );

        public bool UpdatePassword(string userId, string newPassword);
        public List<UserRoleDto> GetRoles(string userId);
        public List<PositionDto> GetPosition(string userId, int? cityId = null);
        public List<UserCityDto> GetUserCities(string userId);

    }


}
