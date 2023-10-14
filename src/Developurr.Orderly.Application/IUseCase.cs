namespace Developurr.Orderly.Application;

public interface IUseCase<in TInput, TOutput>
{
    public Task<TOutput> Handle(TInput input, CancellationToken cancellationToken);
}
