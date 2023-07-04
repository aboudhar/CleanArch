using AutoMapper;
using BLCLicense_Management.BlazorUI.Contracts;
using BLCLicense_Management.BlazorUI.Models.LicenseType;
using BLCLicense_Management.BlazorUI.Services.Base;

namespace BLCLicense_Management.BlazorUI.Services
{
    public class LicenseTypeService : BaseHttpService, ILicenseTypeService
    {
        private readonly IMapper _mapper;
        public LicenseTypeService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public Task<Response<Guid>> CreateLicenseType(LicenseTypeVM leaveType)
        {
            throw new NotImplementedException();

        }

        public Task<Response<Guid>> DeleteLicenseType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LicenseTypeVM> GetLeaveTypeById()
        {
            throw new NotImplementedException();
        }

        public async Task<List<LicenseTypeVM>> GetLeaveTypes()
        {
            var licenceTypes = await _client.LicenseTypesAllAsync();
            var res = _mapper.Map<List<LicenseTypeVM>>(licenceTypes);
            return res;
        }

        public Task<Response<Guid>> UpdateLicenseType(int id, LicenseTypeVM leaveType)
        {
            throw new NotImplementedException();
        }
    }
}
