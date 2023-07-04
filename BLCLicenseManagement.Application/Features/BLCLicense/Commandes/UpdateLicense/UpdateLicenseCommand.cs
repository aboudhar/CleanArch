using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCLicense.Commandes.UpdateLicense
{
    public record UpdateLicenseCommand(LicenseDtoCommand LicenseDtoCommand) : IRequest;
}
