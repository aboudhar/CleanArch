using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Domain;
using BLCLicenseManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace BLCLicenseManagement.Persistence.Repositories
{
    public class GeneRecRepository<T> : IGeneRecRepository<T> where T : BaseEntity
    {
        protected readonly BLCDatabaseContext _context;
        public GeneRecRepository(BLCDatabaseContext context)
        {

            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateAsync(T entity)
        {
            // _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
