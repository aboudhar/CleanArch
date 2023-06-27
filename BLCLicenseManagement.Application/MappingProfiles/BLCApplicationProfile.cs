using AutoMapper;
using BLCLicenseManagement.Application.Features.BLCApplications;
using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.MappingProfiles
{
    public class BLCApplicationProfile : Profile
    {
        public BLCApplicationProfile()
        {
            CreateMap<BLCApplication, BLCApplicationDto>().ReverseMap();
        }
    }
}
