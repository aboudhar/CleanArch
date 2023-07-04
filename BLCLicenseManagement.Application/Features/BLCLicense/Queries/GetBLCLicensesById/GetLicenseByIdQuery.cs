using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCLicense.Queries.GetBLCLicensesById
{
    public record GetLicenseByIdQuery(int id) : IRequest<LicenseDtoQuery>;
}
