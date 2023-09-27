namespace Orderly.Application.UseCase;

public interface IUnitOfWork : IDisposable
{
    public Task CommitAsync(CancellationToken cancellationToken);
    public Task RollbackAsync(CancellationToken cancellationToken);
}
