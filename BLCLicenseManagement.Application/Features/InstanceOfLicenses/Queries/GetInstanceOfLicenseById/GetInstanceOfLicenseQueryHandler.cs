using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using BLCLicenseManagement.Domain;
using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries.GetInstanceOfLicenseById
{
    public class GetInstanceOfLicenseQueryHandler : IRequestHandler<GetInstanceOfLicenseQuery, InstanceOfLicenseQueryDto>
    {
        //constructor
        private readonly IMapper _mapper;
        private readonly IInstanceOfLicenseRepository _instanceOfLicenseRepository;
        private readonly IAppLogger<GetInstanceOfLicenseQueryHandler> _logger;
        public GetInstanceOfLicenseQueryHandler(IMapper mapper, IInstanceOfLicenseRepository instanceOfLicenseRepository, IAppLogger<GetInstanceOfLicenseQueryHandler> logger)
        {
            _mapper = mapper;
            _instanceOfLicenseRepository = instanceOfLicenseRepository;
            _logger = logger;
        }

        public async Task<InstanceOfLicenseQueryDto> Handle(GetInstanceOfLicenseQuery request, CancellationToken cancellationToken)
        {
            var instance = await _instanceOfLicenseRepository.GetByIdAsync(request.id);
            if (instance == null)
            {
                throw new NotFoundException(nameof(User), request.id);
            }
            var data = _mapper.Map<InstanceOfLicenseQueryDto>(instance);
            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - Retrieved {data.Id} LicenseTypes.");
            return data;
        }
    }
}
