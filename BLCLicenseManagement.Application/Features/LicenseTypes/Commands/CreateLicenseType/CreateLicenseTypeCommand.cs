using MediatR;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.CreateLicenseType
{
    public class CreateLicenseTypeCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;

    }
}
