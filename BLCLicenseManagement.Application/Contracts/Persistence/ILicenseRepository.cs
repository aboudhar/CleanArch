using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.Contracts.Persistence
{
    public interface ILicenseRepository : IGeneRecRepository<License>
    {
        Task<bool> IsUniqueName(string name);
        Task<List<License>> GetLicensesWithDetails();
        Task<List<License>> GetLicensesWithDetails(int userId);
        Task<List<License>> GetLicensesByUserName(string userName);
    }
}
