using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Domain;
using BLCLicenseManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace BLCLicenseManagement.Persistence.Repositories
{
    public class LicenseTypeRepository : GeneRecRepository<LicenseType>, ILicenseTypeRepository
    {
        public LicenseTypeRepository(BLCDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsUniqueName(string name)
        {
            //return _context.LicenseTypes.AllAsync(lt => lt.Name != name);
            return await _context.LicenseTypes.AnyAsync(lt => lt.Name == name) == false;
        }
    }
}
