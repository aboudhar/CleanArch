using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Commands.UpdateBLCApplication
{
    public class UpdateBLCApplicationCommandHandler : IRequestHandler<UpdateBLCApplicationCommand>
    {
        public readonly IMapper _mapper;
        public readonly IBLCApplicationRepository _bLCApplicationRepository;
        readonly IAppLogger<UpdateBLCApplicationCommandHandler> _logger;

        public UpdateBLCApplicationCommandHandler(IMapper mapper, IBLCApplicationRepository applicationRepository, IAppLogger<UpdateBLCApplicationCommandHandler> logger)
        {
            _mapper = mapper;
            _bLCApplicationRepository = applicationRepository;
            _logger = logger;
        }

        public async Task Handle(UpdateBLCApplicationCommand request, CancellationToken cancellationToken)
        {
            //add validator
            var validator = new UpdateBLCApplicationValidator(_bLCApplicationRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                _logger.LogWarning($"{DateTime.Now:yyyyMMdd hh:mm:ss} - FluentValidation Errors for entity {nameof(request.BLCApplicationDto)} with Name{request.BLCApplicationDto.Name}.", validationResult.Errors);
                throw new BadRequestException("Invalid Application", validationResult);
            }
            //get dest resource  
            var srcApplication = await _bLCApplicationRepository.GetByIdAsync(request.BLCApplicationDto.Id);
            if (srcApplication == null)
            {
                throw new NotFoundException(nameof(srcApplication), request.BLCApplicationDto.Id);
            }
            var res = _mapper.Map(request.BLCApplicationDto, srcApplication);
            await _bLCApplicationRepository.UpdateAsync(srcApplication);
        }
    }
}
