using BLCLicenseManagement.Domain;
using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries.GetAllInstanceOfLicenses
{
    public class GetInstanceOfLicensesQuery : IRequest<List<InstanceOfLicenseQueryDto>>
    {
    }
}
