using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.UpdateLicenseType
{
    public class UpdateLicenseTypeCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
