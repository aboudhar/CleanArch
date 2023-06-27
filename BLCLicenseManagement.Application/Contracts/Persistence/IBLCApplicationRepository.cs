using BLCLicenseManagement.Application.Features.BLCApplications;
using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.Contracts.Persistence
{
    public interface IBLCApplicationRepository : IGeneRecRepository<BLCApplication>
    {
        Task<bool> IsUniqueName(string name);
        Task<bool> IsUniqueNameUpdate(BLCApplicationDto bLCApplicationDto);
    }
}
