using BLCLicenseManagement.Application.Features.BLCApplications;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using BLCLicenseManagement.Application.Features.LicenseTypes.Queries;
using BLCLicenseManagement.Application.Features.Users;

namespace BLCLicenseManagement.Application.Features.BLCLicense.Queries
{
    public class LicenseDtoQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int LicenseTypeId { get; set; }
        public LicenseTypeDto LicenseType { get; set; } = new LicenseTypeDto();
        public int UserId { get; set; }
        public UserDto User { get; set; } = new UserDto();
        public ICollection<InstanceOfLicenseQueryDto> InstanceOfLicenses { get; set; } = new List<InstanceOfLicenseQueryDto>();
        public virtual ICollection<BLCApplicationDto> BLCApplications { get; set; } = new List<BLCApplicationDto>();
    }
}
