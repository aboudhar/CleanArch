using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Domain;
using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCLicense.Commandes.UpdateLicense
{
    public class UpdateLicenseCommandHandler : IRequestHandler<UpdateLicenseCommand>
    {
        private readonly IMediator _mediator;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IMapper _mapper;
        public UpdateLicenseCommandHandler(IMediator mediator, ILicenseRepository licenseRepository, IMapper mapper)
        {
            _mediator = mediator;
            _licenseRepository = licenseRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateLicenseCommand request, CancellationToken cancellationToken)
        {
            var license = _mapper.Map<License>(request.LicenseDtoCommand);
            await _licenseRepository.UpdateAsync(license);
        }
    }
}
