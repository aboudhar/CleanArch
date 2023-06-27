using AutoMapper;
using BLCLicenseManagement.Application.Features.Users;
using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
