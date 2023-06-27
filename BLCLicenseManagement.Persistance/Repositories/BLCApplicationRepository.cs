using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Features.BLCApplications;
using BLCLicenseManagement.Domain;
using BLCLicenseManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace BLCLicenseManagement.Persistence.Repositories
{
    public class BLCApplicationRepository : GeneRecRepository<BLCApplication>, IBLCApplicationRepository
    {
        public BLCApplicationRepository(BLCDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsUniqueName(string name)
        {
            return await _context.BLCApplications.AnyAsync(ba => ba.Name == name) == false;
        }

        public async Task<bool> IsUniqueNameUpdate(BLCApplicationDto bLCApplicationDto)
        {
            return await _context.BLCApplications.AnyAsync(a => a.Name == bLCApplicationDto.Name && a.Id != bLCApplicationDto.Id) == false;
        }
    }
}
