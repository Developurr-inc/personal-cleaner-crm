namespace Developurr.Orderly.Domain.SeedWork;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    public Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
    public Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken);
}