using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.DeleteLicenseType
{
    public class DeleteLicenseTypeCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
