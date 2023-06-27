using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Queries.GetAllBLCApplications
{
    public class GetBLCApplicationsQuery : IRequest<List<BLCApplicationDto>>
    {
    }
}
