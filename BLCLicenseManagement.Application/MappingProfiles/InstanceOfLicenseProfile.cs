using AutoMapper;
using BLCLicenseManagement.Application.Features.BLCLicense.Queries;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.MappingProfiles
{
    public class InstanceOfLicenseProfile : Profile
    {
        public InstanceOfLicenseProfile()
        {
            //CreateMap<InstanceOfLicense, InstanceOfLicenseQueryDto>().ReverseMap();
            CreateMap<InstanceOfLicense, InstanceOfLicenseCommandDto>().ReverseMap();
            CreateMap<InstanceOfLicense, InstanceOfLicenseQueryDto>()
            .ForMember(dest => dest.License, opt => opt.MapFrom(src => CustomMappingLogic(src.License)));
        }
        private LicenseDtoQuery CustomMappingLogic(License sourceProperty)
        {
            var licence = new LicenseDtoQuery()
            {
                Name = sourceProperty.Name,
                Id = sourceProperty.Id,
                UserId = sourceProperty.UserId,
                Key = sourceProperty.Key,
                Description = sourceProperty.Description
            };
            // Custom logic to map from string to int
            // For demonstration purposes, let's assume it's converting the string length to an int
            return licence;
        }
    }
}
