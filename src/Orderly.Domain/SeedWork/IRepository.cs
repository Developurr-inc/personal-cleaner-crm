namespace Orderly.Domain.SeedWork;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    Task<TEntity> GetByIdAsync(TId id);
    Task<List<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}
