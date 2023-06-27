using AutoMapper;
using BLCLicenseManagement.Application.Features.LicenseTypes.Commands.CreateLicenseType;
using BLCLicenseManagement.Application.Features.LicenseTypes.Commands.UpdateLicenseType;
using BLCLicenseManagement.Application.Features.LicenseTypes.Queries;
using BLCLicenseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.MappingProfiles
{
    public class LicenseTypeProfile:Profile
    {
        public LicenseTypeProfile()
        {
            CreateMap<LicenseType,LicenseTypeDto>().ReverseMap();
            CreateMap<CreateLicenseTypeCommand, LicenseType>();
            CreateMap<UpdateLicenseTypeCommand, LicenseType>();
        }
    }
}
