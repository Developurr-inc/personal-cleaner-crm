namespace Orderly.Domain.Exceptions;

public sealed class EntityValidationException : Exception
{
    public IEnumerable<string> Errors { get; }


    public EntityValidationException(
        string message,
        IEnumerable<string> errors
    ) : base(message)
    {
        Errors = errors;
    }
}