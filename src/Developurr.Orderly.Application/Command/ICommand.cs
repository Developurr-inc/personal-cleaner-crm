namespace Developurr.Orderly.Application.Command;

public interface ICommand<in TInput, TOutput> : IUseCase<TInput, TOutput> { }
