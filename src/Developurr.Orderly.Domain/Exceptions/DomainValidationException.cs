using System.Collections;

namespace Developurr.Orderly.Domain.Exceptions;

public sealed class DomainValidationException : Exception
{
    public readonly IEnumerable<string> ValidationMessages;

    public DomainValidationException(string message)
        : base("There are validation errors. See ValidationMessages property for more details.")
    {
        ValidationMessages = Enumerable.Empty<string>();
    }

    public DomainValidationException(IEnumerable<string> validationMessages)
        : base("There are validation errors. See ValidationMessages property for more details.")
    {
        ValidationMessages = validationMessages;
    }
}
