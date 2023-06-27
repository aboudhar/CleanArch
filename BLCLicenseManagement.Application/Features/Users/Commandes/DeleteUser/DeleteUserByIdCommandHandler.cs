using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using MediatR;

namespace BLCLicenseManagement.Application.Features.Users.Commandes.DeleteUser
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            // _userRepository.DeleteAsync(request.Id);
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            await _userRepository.DeleteAsync(user);
        }
    }
}
