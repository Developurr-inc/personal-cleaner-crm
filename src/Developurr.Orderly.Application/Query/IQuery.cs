namespace Developurr.Orderly.Application.Query;

public interface IQuery<in TInput, TOutput> : IUseCase<TInput, TOutput> { }
