namespace BLCLicenseManagement.Application.Features.BLCLicense.Commandes
{
    public class LicenseDtoCommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int LicenseTypeId { get; set; }
        public int UserId { get; set; }
    }
}
