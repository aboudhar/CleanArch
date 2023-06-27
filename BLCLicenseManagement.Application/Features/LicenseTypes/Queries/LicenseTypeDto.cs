namespace BLCLicenseManagement.Application.Features.LicenseTypes.Queries
{
    public class LicenseTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}