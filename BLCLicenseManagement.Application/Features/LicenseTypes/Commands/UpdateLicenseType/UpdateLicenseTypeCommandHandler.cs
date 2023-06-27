using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Persistence;
using MediatR;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.UpdateLicenseType
{

    public class UpdateLicenseTypeCommandHandler : IRequestHandler<UpdateLicenseTypeCommand, Unit>
    {
        public readonly IMapper _mapper;
        public readonly ILicenseTypeRepository _licenseTypeRepository;
        public UpdateLicenseTypeCommandHandler(IMapper mapper, ILicenseTypeRepository licenseTypeRepository)
        {
            _mapper = mapper;
            _licenseTypeRepository = licenseTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLicenseTypeCommand request, CancellationToken cancellationToken)
        {
            var licenseType = _mapper.Map<Domain.LicenseType>(request);
            await _licenseTypeRepository.UpdateAsync(licenseType);
            return Unit.Value;
        }
    }
}
