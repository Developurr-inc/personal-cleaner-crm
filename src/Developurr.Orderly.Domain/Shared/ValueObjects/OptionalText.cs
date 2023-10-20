using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class OptionalText : ValueObject
{
    public readonly string Value;

    private OptionalText(string value)
    {
        Value = value;
    }

    public static OptionalText Create(string value)
    {
        if (value.Equals(null))
        {
            throw new ArgumentException("Value cannot be null.", nameof(value));
        }

        var valueSanitized = value.Trim();
        
        if (valueSanitized.Length > 10_000)
        {
            throw new ArgumentException("Value cannot be longer than 10000 characters.", nameof(value));
        }

        return new OptionalText(valueSanitized);
    }

    public static implicit operator string(OptionalText text)
    {
        return text.Value;
    }

    public static implicit operator OptionalText(string text)
    {
        return Create(text);
    }

    public override string ToString()
    {
        return Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
