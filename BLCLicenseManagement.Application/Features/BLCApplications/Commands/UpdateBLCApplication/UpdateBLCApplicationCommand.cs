using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Commands.UpdateBLCApplication
{
    public record UpdateBLCApplicationCommand(BLCApplicationDto BLCApplicationDto) : IRequest;
}
