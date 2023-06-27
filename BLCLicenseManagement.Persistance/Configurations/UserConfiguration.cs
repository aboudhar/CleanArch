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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id = 1,
                Name = "Admin",
                Email = "",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            });
            //builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
