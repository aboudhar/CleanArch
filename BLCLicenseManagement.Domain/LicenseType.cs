using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BLCLicenseManagement.Domain
{
    public class LicenseType: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
} 
