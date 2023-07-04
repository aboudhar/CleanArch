using AutoMapper;
using BLCLicenseManagement.Application.Features.BLCLicense.Commandes;
using BLCLicenseManagement.Application.Features.BLCLicense.Queries;
using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.MappingProfiles
{
    public class LicenseProfile : Profile
    {
        public LicenseProfile()
        {
            CreateMap<License, LicenseDtoQuery>().ReverseMap();
            CreateMap<License, LicenseDtoCommand>().ReverseMap();
        }
    }
}
