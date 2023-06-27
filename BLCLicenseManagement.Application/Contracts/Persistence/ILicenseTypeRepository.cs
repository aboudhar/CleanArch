using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.Contracts.Persistence
{
    public interface ILicenseTypeRepository : IGeneRecRepository<LicenseType>
    {
        Task<bool> IsUniqueName(string name);
    }
}
