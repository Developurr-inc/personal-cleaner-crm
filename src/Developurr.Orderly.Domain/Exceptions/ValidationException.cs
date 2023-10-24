namespace Developurr.Orderly.Domain.Exceptions;

public sealed class ValidationException : DomainException
{
    public readonly IEnumerable<string> ValidationMessages;

    public ValidationException(string message)
        : base("There are validation errors. See ValidationMessages property for more details.")
    {
        ValidationMessages = Enumerable.Empty<string>();
    }

    public ValidationException(IEnumerable<string> validationMessages)
        : base("There are validation errors. See ValidationMessages property for more details.")
    {
        ValidationMessages = validationMessages;
    }
}