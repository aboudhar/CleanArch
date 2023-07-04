using System.ComponentModel.DataAnnotations;

namespace BLCLicense_Management.BlazorUI.Models.LicenseType
{
    public class LicenseTypeVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
