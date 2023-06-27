using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Domain;
using BLCLicenseManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace BLCLicenseManagement.Persistence.Repositories
{
    public class LicenseRepository : GeneRecRepository<License>, ILicenseRepository
    {
        public LicenseRepository(BLCDatabaseContext context) : base(context)
        {
        }

        public async Task<List<License>> GetLicensesByUserName(string userName)
        {
            //return await _context.Licenses.Include(l=>l.User).Where(l => l.User.Name == userName).ToListAsync();
            return await _context.Licenses.Where(l => l.User.Name == userName).ToListAsync();
        }

        public async Task<List<License>> GetLicensesWithDetails()
        {
           return await _context.Licenses.Include(l => l.LicenseType).ToListAsync();
        }

        public async Task<List<License>> GetLicensesWithDetails(int userId)
        {
            return await _context.Licenses.Include(l => l.LicenseType).Where(l => l.UserId == userId).ToListAsync();
        }

        public Task<bool> IsUniqueName(string name)
        {
            return _context.Licenses.AllAsync(l => l.Name != name);
        }
    }
}
