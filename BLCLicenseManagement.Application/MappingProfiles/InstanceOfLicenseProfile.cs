using AutoMapper;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.MappingProfiles
{
    public class InstanceOfLicenseProfile : Profile
    {
        public InstanceOfLicenseProfile()
        {
            CreateMap<InstanceOfLicense, InstanceOfLicenseQueryDto>().ReverseMap();
        }
    }
}
