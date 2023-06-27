using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Commands.DeleteBLCApplication
{
    public record DeleteBLCApplicationCommand(int Id) : IRequest;
}
