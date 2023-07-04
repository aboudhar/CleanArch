using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Commandes.UpdateInstanceOfLicense
{
    public record UpdateInstanceOfLicenseCommand(InstanceOfLicenseCommandDto InstanceOfLicenseCommandDto) : IRequest;
}
