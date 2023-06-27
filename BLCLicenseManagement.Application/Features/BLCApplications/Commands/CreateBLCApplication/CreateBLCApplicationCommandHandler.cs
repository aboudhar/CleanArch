using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using BLCLicenseManagement.Domain;
using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Commands.CreateBLCApplication
{
    public class CreateBLCApplicationCommandHandler : IRequestHandler<CreateBLCApplicationCommand, BLCApplicationDto>
    {
        readonly IMapper _mapper;
        readonly IBLCApplicationRepository _bLCApplicationRepository;
        readonly IAppLogger<CreateBLCApplicationCommand> _logger;
        public CreateBLCApplicationCommandHandler(IMapper mapper, IBLCApplicationRepository bLCApplicationRepository, IAppLogger<CreateBLCApplicationCommand> logger)
        {
            _mapper = mapper;
            _bLCApplicationRepository = bLCApplicationRepository;
            _logger = logger;
        }

        public async Task<BLCApplicationDto> Handle(CreateBLCApplicationCommand request, CancellationToken cancellationToken)
        {
            //add validation
            var validator = new CreateBLCApplicationValidator(_bLCApplicationRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                _logger.LogWarning($"{DateTime.Now:yyyyMMdd hh:mm:ss} - FluentValidation Errors for entity {nameof(BLCApplication)} with Name{request.blcApplicationDto.Name}.", validationResult.Errors);
                throw new BadRequestException("Invalid Application", validationResult);
            }
            var application = _mapper.Map<Domain.BLCApplication>(request.blcApplicationDto);
            await _bLCApplicationRepository.CreateAsync(application);
            return _mapper.Map<BLCApplicationDto>(application);
        }
    }
}
