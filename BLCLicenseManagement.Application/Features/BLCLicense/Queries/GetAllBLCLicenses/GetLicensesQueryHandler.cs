using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCLicense.Queries.GetAllBLCLicenses
{
    public class GetLicensesQueryHandler : IRequestHandler<GetLicensesQuery, List<LicenseDtoQuery>>
    {
        private readonly IMapper _mapper;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IAppLogger<GetLicensesQueryHandler> _logger;
        public GetLicensesQueryHandler(IMapper mapper, ILicenseRepository licenseRepository, IAppLogger<GetLicensesQueryHandler> logger)
        {
            _licenseRepository = licenseRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<LicenseDtoQuery>> Handle(GetLicensesQuery request, CancellationToken cancellationToken)
        {
            var licenseTypes = await _licenseRepository.GetAllAsync();
            var data = _mapper.Map<List<LicenseDtoQuery>>(licenseTypes);
            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - Retrieved {data.Count} LicenseTypes.");
            return data;
        }
    }
}
