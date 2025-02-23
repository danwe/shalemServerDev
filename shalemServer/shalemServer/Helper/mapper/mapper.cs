using AutoMapper;
using shalemServer.Models.Dto;
using shalemServer.Models;

namespace shalemServer.Helper.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configure the mapping between AspNetUserDto and AspNetUser
            CreateMap<AspNetUserDto, AspNetUser>();
        }
    }
}
