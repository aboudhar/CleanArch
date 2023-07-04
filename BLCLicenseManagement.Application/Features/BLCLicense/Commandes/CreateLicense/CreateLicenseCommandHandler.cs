using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCLicense.Commandes.CreateLicense
{
    public class CreateLicenseCommandHandler : IRequestHandler<CreateLicenseCommand>
    {
        readonly IMapper _mapper;
        readonly ILicenseRepository _licenseRepository;
        readonly IAppLogger<CreateLicenseCommandHandler> _logger;
        public CreateLicenseCommandHandler(IMapper mapper, ILicenseRepository licenseRepository, IAppLogger<CreateLicenseCommandHandler> logger)
        {
            _mapper = mapper;
            _licenseRepository = licenseRepository;
            _logger = logger;
        }
        public async Task Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
        {
            //validate the request with FluentValidation
            var license = _mapper.Map<Domain.License>(request);
            await _licenseRepository.CreateAsync(license);
        }
    }
}
