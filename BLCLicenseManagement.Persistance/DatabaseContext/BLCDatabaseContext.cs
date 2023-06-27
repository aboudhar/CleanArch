using BLCLicenseManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace BLCLicenseManagement.Persistence.DatabaseContext
{
    public class BLCDatabaseContext : DbContext
    {
        public BLCDatabaseContext(DbContextOptions<BLCDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<InstanceOfLicense> InstanceOfLicenses { get; set; }
        public DbSet<BLCApplication> BLCApplications { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                                       e.State == EntityState.Added
                                                              || e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).DateModified = DateTime.Now;
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BLCDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
