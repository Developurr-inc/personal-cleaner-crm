using Developurr.Orderly.Domain.SeedWork;

namespace  Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class NonEmptyText : ValueObject
{
    public readonly string Value;

    private NonEmptyText(string value)
    {
        Value = value;
    }

    public static NonEmptyText Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }
        
        var valueSanitized = value.Trim();
        
        if (valueSanitized.Length > 255)
        {
            throw new ArgumentException("Value cannot be longer than 255 characters.", nameof(value));
        }

        return new NonEmptyText(valueSanitized);
    }

    public static implicit operator string(NonEmptyText text)
    {
        return text.Value;
    }

    public static implicit operator NonEmptyText(string text)
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
