using AutoMapper;
using BLCLicense_Management.BlazorUI.Models.LicenseType;
using BLCLicense_Management.BlazorUI.Services.Base;

namespace BLCLicense_Management.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<LicenseTypeDto, LicenseTypeVM>().ReverseMap();
        }
    }
}
