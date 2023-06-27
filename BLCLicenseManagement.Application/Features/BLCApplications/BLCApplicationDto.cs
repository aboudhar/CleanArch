using System.ComponentModel;

namespace BLCLicenseManagement.Application.Features.BLCApplications
{
    public class BLCApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public virtual ICollection<License> Licenses { get; set; } = new List<License>();
    }
}
