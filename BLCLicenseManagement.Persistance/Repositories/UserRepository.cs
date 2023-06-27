using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Features.Users;
using BLCLicenseManagement.Domain;
using BLCLicenseManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace BLCLicenseManagement.Persistence.Repositories
{
    public class UserRepository : GeneRecRepository<User>, IUserRepository
    {
        public UserRepository(BLCDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsUniqueEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email) == false;
        }

        public async Task<bool> IsUniqueEmailUpdate(UserDto user)
        {
            return await _context.Users.AnyAsync(u => u.Email == user.Email && u.Id != user.id) == false;
        }
    }
}
