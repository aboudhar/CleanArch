using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Features.LicenseType.Queries.GetAllLicenseTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Queries.GetSingleLicenseType
{
    public record GetSingleLicenseTypeQuery(int id):IRequest<LicenseTypeDto>;
     
}
