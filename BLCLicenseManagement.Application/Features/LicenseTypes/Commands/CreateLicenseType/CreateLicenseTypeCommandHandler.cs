using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using MediatR;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.CreateLicenseType
{
    public class CreateLicenseTypeCommandHandler : IRequestHandler<CreateLicenseTypeCommand, int>
    {
        readonly IMapper _mapper;
        readonly ILicenseTypeRepository _licenseTypeRepository;
        readonly IAppLogger<CreateLicenseTypeCommandHandler> _logger;
        public CreateLicenseTypeCommandHandler(IMapper mapper, ILicenseTypeRepository licenseTypeRepository, IAppLogger<CreateLicenseTypeCommandHandler> logger)
        {
            _mapper = mapper;
            _licenseTypeRepository = licenseTypeRepository;
            _logger = logger;
        }
        public async Task<int> Handle(CreateLicenseTypeCommand request, CancellationToken cancellationToken)
        {
            //validate the request with FluentValidation
            var validator = new CreateLicenseTypeValidator(_licenseTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                _logger.LogWarning($"{DateTime.Now:yyyyMMdd hh:mm:ss} - FluentValidation Errors for entity {nameof(LicenseType)} with Name{request.Name}.", validationResult.Errors);
                throw new BadRequestException("Invalid LicenseType", validationResult);
            }

            var licenseType = _mapper.Map<Domain.LicenseType>(request);
            await _licenseTypeRepository.CreateAsync(licenseType);
            return licenseType.Id;
        }
    }
}
