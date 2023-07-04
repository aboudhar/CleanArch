using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCLicense.Commandes.CreateLicense
{
    public record CreateLicenseCommand(LicenseDtoCommand LicenseDtoCommand) : IRequest;
}
