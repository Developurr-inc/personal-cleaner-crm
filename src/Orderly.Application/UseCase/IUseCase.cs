using Orderly.Application.UseCase.Customer.CreateCustomer;

namespace Orderly.Application;

public interface IUseCase<TInput, TOutput>
{
    public Task<TOutput> Execute(TInput input, CancellationToken cancellationToken);
}
