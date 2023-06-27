using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Features.LicenseType.Queries.GetAllLicenseTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Queries.GetSingleLicenseType
{
    public class GetSingleLicenseTypeQueryHundler : IRequestHandler<GetSingleLicenseTypeQuery, LicenseTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ILicenseTypeRepository _licenseTypeRepository;
        private readonly IAppLogger<GetSingleLicenseTypeQueryHundler> _logger;
        public GetSingleLicenseTypeQueryHundler(IMapper mapper, ILicenseTypeRepository licenseTypeRepository, IAppLogger<GetSingleLicenseTypeQueryHundler> logger)
        {
            _licenseTypeRepository = licenseTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LicenseTypeDto> Handle(GetSingleLicenseTypeQuery request, CancellationToken cancellationToken)
        {
            var licenseType = await _licenseTypeRepository.GetByIdAsync(request.id);
            var data = _mapper.Map<LicenseTypeDto>(licenseType);
            return data;
        }
    }
}
