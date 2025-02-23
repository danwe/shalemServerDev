using shalemServer.Models;
using shalemServer.Models.Dto;

namespace shalemServer.Interfaces
{
    public interface IloginRepository
    {
        public  Task<bool> ChechValidUserPassordAsync(string user, string password);
        public  Task<AspNetUserDto> GetUser(string user, string password);
        public List<UserRoleDto> GetRoles(string userId);
        public List<UserCityDto> GetUserCities(string userId);


    }
}
