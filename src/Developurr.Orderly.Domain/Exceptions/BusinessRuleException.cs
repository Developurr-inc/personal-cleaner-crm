namespace Developurr.Orderly.Domain.Exceptions;

public class BusinessRuleException : DomainException
{
    public BusinessRuleException(string message)
        : base(message)
    {
    }
}