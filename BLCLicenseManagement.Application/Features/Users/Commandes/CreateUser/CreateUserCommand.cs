using BLCLicenseManagement.Application.Features.Users;
using MediatR;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.CreateLicenseType
{
    public record CreateUserCommand(UserDto user) : IRequest<UserDto>;

}
