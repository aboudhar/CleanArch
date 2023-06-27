using BLCLicenseManagement.Domain;

namespace BLCLicenseManagement.Application.Contracts.Persistence
{
    public interface IGeneRecRepository<TEntity> where TEntity : BaseEntity
    {
        Task CreateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
