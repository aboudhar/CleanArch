using BLCLicenseManagement.Application.Features.LicenseTypes.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.Features.LicenseType.Queries.GetAllLicenseTypes
{
    public class GetLicenseTypeQuery:IRequest<List<LicenseTypeDto>>
    {
    }
}
