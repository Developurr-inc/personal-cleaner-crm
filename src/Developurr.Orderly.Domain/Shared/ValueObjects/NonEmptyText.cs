using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class NonEmptyText : ValueObject
{
    private readonly string _value;

    private NonEmptyText(string value)
    {
        _value = value;
    }

    public static NonEmptyText Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainValidationException("Value cannot be null or whitespace.");
        }

        var valueSanitized = value.Trim();

        if (valueSanitized.Length > 255)
        {
            throw new DomainValidationException("Value cannot be longer than 255 characters.");
        }

        return new NonEmptyText(valueSanitized);
    }

    public static implicit operator string(NonEmptyText text)
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
