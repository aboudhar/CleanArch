using BLCLicense_Management.BlazorUI.Models.LicenseType;
using BLCLicense_Management.BlazorUI.Services.Base;

namespace BLCLicense_Management.BlazorUI.Contracts
{
    public interface ILicenseTypeService
    {
        Task<List<LicenseTypeVM>> GetLeaveTypes();
        Task<LicenseTypeVM> GetLeaveTypeById();
        Task<Response<Guid>> CreateLicenseType(LicenseTypeVM leaveType);
        Task<Response<Guid>> UpdateLicenseType(int id, LicenseTypeVM leaveType);
        Task<Response<Guid>> DeleteLicenseType(int id);
    }
}
