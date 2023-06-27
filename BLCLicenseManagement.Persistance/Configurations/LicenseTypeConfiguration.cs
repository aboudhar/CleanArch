using BLCLicenseManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Persistence.Configurations
{
    public class LicenseTypeConfiguration : IEntityTypeConfiguration<LicenseType>
    {
        public void Configure(EntityTypeBuilder<LicenseType> builder)
        {
            builder.HasData(new LicenseType
            {
                Id = 1,
                Name = "Trial",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            });
        }
    }
}
