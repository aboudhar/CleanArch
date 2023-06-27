using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Domain;
using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries.GetAllInstanceOfLicenses
{
    public class GetInstanceOfLicensesQueryHandler : IRequestHandler<GetInstanceOfLicensesQuery, List<InstanceOfLicenseQueryDto>>
    {
        //constructor
        private readonly IMapper _mapper;
        private readonly IInstanceOfLicenseRepository _instanceOfLicenseRepository;
        private readonly IAppLogger<GetInstanceOfLicensesQueryHandler> _logger;
        public GetInstanceOfLicensesQueryHandler(IMapper mapper, IInstanceOfLicenseRepository instanceOfLicenseRepository, IAppLogger<GetInstanceOfLicensesQueryHandler> logger)
        {
            _mapper = mapper;
            _instanceOfLicenseRepository = instanceOfLicenseRepository;
            _logger = logger;
        }

        public async Task<List<InstanceOfLicenseQueryDto>> Handle(GetInstanceOfLicensesQuery request, CancellationToken cancellationToken)
        {
            var instances = await _instanceOfLicenseRepository.GetAllAsync();
            var data = _mapper.Map<List<InstanceOfLicenseQueryDto>>(instances);
            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - Retrieved {data.Count} LicenseTypes.");
            return data;
        }
    }
}
