using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCLicense.Queries.GetBLCLicensesById
{
    public class GetLicenseByIdQueryHandler : IRequestHandler<GetLicenseByIdQuery, LicenseDtoQuery>
    {
        private readonly IMapper _mapper;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IAppLogger<GetLicenseByIdQueryHandler> _logger;
        public GetLicenseByIdQueryHandler(IMapper mapper, ILicenseRepository licenseTypeRepository, IAppLogger<GetLicenseByIdQueryHandler> logger)
        {
            _licenseRepository = licenseTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<LicenseDtoQuery> Handle(GetLicenseByIdQuery request, CancellationToken cancellationToken)
        {
            var license = await _licenseRepository.GetByIdAsync(request.id);
            var licenseDto = _mapper.Map<LicenseDtoQuery>(license);
            return licenseDto;
        }
    }
}
