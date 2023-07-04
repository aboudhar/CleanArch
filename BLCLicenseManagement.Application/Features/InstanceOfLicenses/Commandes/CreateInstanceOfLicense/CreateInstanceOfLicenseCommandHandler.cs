using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Commandes.CreateInstanceOfLicense
{
    public class CreateInstanceOfLicenseCommandHandler : IRequestHandler<CreateInstanceOfLicenseCommand, InstanceOfLicenseCommandDto>
    {

        readonly IMapper _mapper;
        readonly IInstanceOfLicenseRepository _instanceOfLicenseRepository;
        readonly IAppLogger<CreateInstanceOfLicenseCommandHandler> _logger;
        public CreateInstanceOfLicenseCommandHandler(IMapper mapper, IInstanceOfLicenseRepository instanceOfLicenseRepository, IAppLogger<CreateInstanceOfLicenseCommandHandler> logger)
        {
            _mapper = mapper;
            _instanceOfLicenseRepository = instanceOfLicenseRepository;
            _logger = logger;
        }

        async Task<InstanceOfLicenseCommandDto> IRequestHandler<CreateInstanceOfLicenseCommand, InstanceOfLicenseCommandDto>.Handle(CreateInstanceOfLicenseCommand request, CancellationToken cancellationToken)
        {
            var instance = _mapper.Map<Domain.InstanceOfLicense>(request.InstanceOfLicenseCommandDto);
            await _instanceOfLicenseRepository.CreateAsync(instance);
            return _mapper.Map<InstanceOfLicenseCommandDto>(instance);
        }
    }
}
