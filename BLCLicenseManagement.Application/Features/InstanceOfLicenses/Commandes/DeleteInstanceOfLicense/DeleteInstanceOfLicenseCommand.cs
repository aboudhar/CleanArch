using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Commandes.DeleteInstanceOfLicense
{
    public record DeleteInstanceOfLicenseCommand(int id) : IRequest;
}
