using MediatR;

namespace BLCLicenseManagement.Application.Features.Users.Commandes.UpdateUser
{
    public record UpdateUserCommand(UserDto UserDto) : IRequest;
}
