using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.Contracts.Persistence
{
    public interface IInstanceOfLicenseRepository : IGeneRecRepository<InstanceOfLicense>
    {
        Task<bool> IsUniqueName(string name);
    }
}
