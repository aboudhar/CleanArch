using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Commandes.CreateInstanceOfLicense
{
    public record CreateInstanceOfLicenseCommand(InstanceOfLicenseCommandDto InstanceOfLicenseCommandDto) : IRequest<InstanceOfLicenseCommandDto>;
}
