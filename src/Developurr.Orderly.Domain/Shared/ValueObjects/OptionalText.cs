using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class OptionalText : ValueObject
{
    private readonly string _value;

    private OptionalText(string value)
    {
        _value = value;
    }

    public static OptionalText Create(string value)
    {
        if (value.Equals(null))
        {
            throw new DomainValidationException("Value cannot be null.");
        }

        var valueSanitized = value.Trim();

        if (valueSanitized.Length > 10_000)
        {
            throw new DomainValidationException("Value cannot be longer than 10000 characters.");
        }

        return new OptionalText(valueSanitized);
    }

    public static implicit operator string(OptionalText text)
    {
        return text._value;
    }

    public override string ToString()
    {
        return _value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
