namespace Orderly.Domain.Exceptions;

public sealed class EntityValidationException(string message, IEnumerable<string> errors)
    : Exception(message)
{
    public IEnumerable<string> Errors { get; } = errors;
}
