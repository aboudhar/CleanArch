using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Queries.GetBLCApplicationsById
{
    public record GetBLCApplicationsByIdQuery(int id) : IRequest<BLCApplicationDto>;

}
