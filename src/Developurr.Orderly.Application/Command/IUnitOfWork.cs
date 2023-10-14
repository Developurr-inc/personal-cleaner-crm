<<<<<<<< HEAD:src/Orderly.Application/Command/IUnitOfWork.cs
namespace Orderly.Application.Command;
========
namespace Developurr.Orderly.Application.Command;
>>>>>>>> develop:src/Developurr.Orderly.Application/Command/IUnitOfWork.cs

public interface IUnitOfWork : IDisposable
{
    public Task CommitAsync(CancellationToken cancellationToken);
    public Task RollbackAsync(CancellationToken cancellationToken);
}
