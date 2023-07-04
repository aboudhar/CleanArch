using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Domain;
using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Commandes.UpdateInstanceOfLicense
{
    public class UpdateInstanceOfLicenseCommandHandler : IRequestHandler<UpdateInstanceOfLicenseCommand>
    {
        public readonly IMapper _mapper;
        public readonly IInstanceOfLicenseRepository _instanceOfLicenseRepository;
        readonly IAppLogger<UpdateInstanceOfLicenseCommandHandler> _logger;
        public UpdateInstanceOfLicenseCommandHandler(IMapper mapper, IInstanceOfLicenseRepository instanceOfLicenseRepository, IAppLogger<UpdateInstanceOfLicenseCommandHandler> appLogger)
        {
            _mapper = mapper;
            _instanceOfLicenseRepository = instanceOfLicenseRepository;
            _logger = appLogger;
        }
        public async Task Handle(UpdateInstanceOfLicenseCommand request, CancellationToken cancellationToken)
        {
            // validate
            var instanceOfLicense = _mapper.Map<InstanceOfLicense>(request.InstanceOfLicenseCommandDto);
            await _instanceOfLicenseRepository.UpdateAsync(instanceOfLicense);
        }
    }
}
