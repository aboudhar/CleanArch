using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using BLCLicenseManagement.Domain;
using MediatR;

namespace BLCLicenseManagement.Application.Features.Users.Commandes.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {

        public readonly IMapper _mapper;
        public readonly IUserRepository _userRepository;
        readonly IAppLogger<UpdateUserCommandHandler> _logger;
        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IAppLogger<UpdateUserCommandHandler> appLogger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = appLogger;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //validate the request with FluentValidation
            var validator = new UpdateUserValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                _logger.LogWarning($"{DateTime.Now:yyyyMMdd hh:mm:ss} - FluentValidation Errors for entity {nameof(User)} with Name{request.UserDto.Name}.", validationResult.Errors);
                throw new BadRequestException("Invalid User", validationResult);
            }
            var user = _mapper.Map<User>(request.UserDto);
            await _userRepository.UpdateAsync(user);
        }
    }
}
