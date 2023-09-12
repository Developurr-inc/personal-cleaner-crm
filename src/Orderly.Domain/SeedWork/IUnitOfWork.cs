namespace Orderly.Domain.SeedWork;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task SaveChangesAsync();
}