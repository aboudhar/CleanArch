namespace BLCLicenseManagement.Domain
{
    public class InstanceOfLicense: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int LicenseId { get; set; }
        public License License { get; set; } = new License();
  
    }
}
