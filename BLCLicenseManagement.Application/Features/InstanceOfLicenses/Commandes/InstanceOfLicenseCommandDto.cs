namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries
{
    public class InstanceOfLicenseCommandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int LicenseId { get; set; }
    }

}
