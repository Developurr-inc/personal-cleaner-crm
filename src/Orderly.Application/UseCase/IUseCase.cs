namespace Orderly.Application.UseCase;

public interface IUseCase<in TInput, TOutput>
{
    public Task<TOutput> Execute(TInput input, CancellationToken cancellationToken);
}
