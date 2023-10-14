<<<<<<<< HEAD:src/Orderly.Application/Command/IUseCase.cs
namespace Orderly.Application.Command;
========
namespace Developurr.Orderly.Application.Command;
>>>>>>>> develop:src/Developurr.Orderly.Application/Command/IUseCase.cs

public interface IUseCase<in TInput, TOutput>
{
    public Task<TOutput> Execute(TInput input, CancellationToken cancellationToken);
}
