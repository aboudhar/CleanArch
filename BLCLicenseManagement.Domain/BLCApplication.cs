namespace BLCLicenseManagement.Domain
{
    public class BLCApplication : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public virtual ICollection<License> Licenses { get; set; } = new List<License>();
    }
} 
