using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Commands.CreateBLCApplication
{
    public record CreateBLCApplicationCommand(BLCApplicationDto blcApplicationDto) : IRequest<BLCApplicationDto>;
}
