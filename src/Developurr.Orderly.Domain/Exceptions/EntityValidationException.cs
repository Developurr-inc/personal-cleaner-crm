namespace Developurr.Orderly.Domain.Exceptions;

public sealed class EntityValidationException : Exception
{
    public EntityValidationException(string message, IEnumerable<string> errors) : base(message)
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; }
}
