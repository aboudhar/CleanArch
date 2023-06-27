using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using BLCLicenseManagement.Application.Features.Users;
using MediatR;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.CreateLicenseType
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        readonly IMapper _mapper;
        readonly IUserRepository _userRepository;
        readonly IAppLogger<CreateUserCommandHandler> _logger;
        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IAppLogger<CreateUserCommandHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }


        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //validate the request with FluentValidation
            var validator = new CreateUserValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                _logger.LogWarning($"{DateTime.Now:yyyyMMdd hh:mm:ss} - FluentValidation Errors for entity {nameof(request.user)} with Name{request.user.Name}.", validationResult.Errors);
                throw new BadRequestException("Invalid User", validationResult);
            }
            var user = _mapper.Map<Domain.User>(request.user);
            await _userRepository.CreateAsync(user);
            return _mapper.Map<UserDto>(user);
        }
    }
}
