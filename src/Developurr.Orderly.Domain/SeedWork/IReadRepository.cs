namespace Developurr.Orderly.Domain.SeedWork;

public interface IReadRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    public Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);
    public Task<List<TEntity>?> GetAllAsync(CancellationToken cancellationToken);
}
