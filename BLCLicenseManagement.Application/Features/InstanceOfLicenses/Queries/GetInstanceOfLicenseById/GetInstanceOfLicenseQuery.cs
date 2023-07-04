using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries.GetInstanceOfLicenseById
{
    public record GetInstanceOfLicenseQuery(int id) : IRequest<InstanceOfLicenseQueryDto>;
}
