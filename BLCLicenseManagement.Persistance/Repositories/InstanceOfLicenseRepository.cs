using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using BLCLicenseManagement.Domain;
using BLCLicenseManagement.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Persistence.Repositories
{
    public class InstanceOfLicenseRepository : GeneRecRepository<InstanceOfLicense>, IInstanceOfLicenseRepository
    {
        public InstanceOfLicenseRepository(BLCDatabaseContext context) : base(context)
        {
        }

        public Task<bool> IsUniqueName(string name)
        {
            return Task.FromResult(_context.InstanceOfLicenses.All(x => x.Name != name));
        }
    }
}
