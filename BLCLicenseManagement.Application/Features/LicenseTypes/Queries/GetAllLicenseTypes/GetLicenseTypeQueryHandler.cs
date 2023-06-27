using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Features.LicenseTypes.Queries;
using MediatR;

namespace BLCLicenseManagement.Application.Features.LicenseType.Queries.GetAllLicenseTypes
{
    internal class GetLicenseTypeQueryHandler : IRequestHandler<GetLicenseTypeQuery, List<LicenseTypeDto>>
    {
        //constructor
        private readonly IMapper _mapper;
        private readonly ILicenseTypeRepository _licenseTypeRepository;
        private readonly IAppLogger<GetLicenseTypeQueryHandler> _logger;
        public GetLicenseTypeQueryHandler(IMapper mapper, ILicenseTypeRepository licenseTypeRepository, IAppLogger<GetLicenseTypeQueryHandler> logger)
        {
            _licenseTypeRepository = licenseTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<LicenseTypeDto>> Handle(GetLicenseTypeQuery request, CancellationToken cancellationToken)
        {
            var licenseTypes = await _licenseTypeRepository.GetAllAsync();
            var data = _mapper.Map<List<LicenseTypeDto>>(licenseTypes);
            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - Retrieved {data.Count} LicenseTypes.");
            return data;

        }
    }
}
