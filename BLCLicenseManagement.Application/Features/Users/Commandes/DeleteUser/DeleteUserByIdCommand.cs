using MediatR;

namespace BLCLicenseManagement.Application.Features.Users.Commandes.DeleteUser
{
    public record DeleteUserByIdCommand(int Id) : IRequest;
}
