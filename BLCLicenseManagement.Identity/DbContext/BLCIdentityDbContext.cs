using BLCLicenseManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BLCLicenseManagement.Identity.DbContext
{
    public class BLCIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public BLCIdentityDbContext(DbContextOptions<BLCIdentityDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(BLCIdentityDbContext).Assembly);
        }
    }
}
