using BLCLicenseManagement.Application.Features.Users;
using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.Contracts.Persistence
{
    public interface IUserRepository : IGeneRecRepository<User>
    {
        Task<bool> IsUniqueEmail(string email);
        Task<bool> IsUniqueEmailUpdate(UserDto user);
    }
}
