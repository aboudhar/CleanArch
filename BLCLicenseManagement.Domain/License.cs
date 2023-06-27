namespace BLCLicenseManagement.Domain
{
    public class License:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int LicenseTypeId { get; set; }
        public LicenseType LicenseType { get; set; } = new LicenseType();
        public int UserId { get; set; }
        public User User { get; set; } = new User();
        public ICollection<InstanceOfLicense> InstanceOfLicenses { get; set; } = new List<InstanceOfLicense>();
        public virtual ICollection<BLCApplication> BLCApplications { get; set; } = new List<BLCApplication>();
    }
}
