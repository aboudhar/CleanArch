using BLCLicense_Management.BlazorUI.Contracts;
using BLCLicense_Management.BlazorUI.Models.LicenseType;
using Microsoft.AspNetCore.Components;

namespace BLCLicense_Management.BlazorUI.Pages.LicenseType
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILicenseTypeService licenseService { get; set; }
        //[Inject]
        //public ILeaveAllocationService LeaveAllocationService { get; set; }
        //[Inject]
        //IToastService toastService { get; set; }
        public List<LicenseTypeVM> LicenseTypes { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected void CreateLicenseType()
        {
            NavigationManager.NavigateTo("/Licensetypes/create/");
        }

        //protected void AllocateLeaveType(int id)
        //{
        //    // Use Leave Allocation Service here
        //    LeaveAllocationService.CreateLeaveAllocations(id);
        //}

        protected void EditLicenseType(int id)
        {
            NavigationManager.NavigateTo($"/Licensetypes/edit/{id}");
        }

        protected void DetailsLicenseType(int id)
        {
            NavigationManager.NavigateTo($"/Licensetypes/details/{id}");
        }

        protected async Task DeleteLicenseType(int id)
        {
            var response = await licenseService.DeleteLicenseType(id);
            if (response.Success)
            {
                // toastService.ShowSuccess("Leave Type deleted Successfully");
                await OnInitializedAsync();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            LicenseTypes = await licenseService.GetLeaveTypes();
        }
    }
}