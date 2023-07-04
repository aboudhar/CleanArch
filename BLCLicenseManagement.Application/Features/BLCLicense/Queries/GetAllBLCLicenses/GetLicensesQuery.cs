using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCLicense.Queries.GetAllBLCLicenses
{
    public class GetLicensesQuery : IRequest<List<LicenseDtoQuery>>
    {
    }
}
