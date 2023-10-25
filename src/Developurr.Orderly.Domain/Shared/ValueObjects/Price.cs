using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class Price : ValueObject
{
    public readonly decimal Value;

    private Price(){ }
    private Price(decimal price)
    {
        Value = price;
    }

    public override string ToString()
    {
        const string currency = "N2";
        return $"R$ {Value.ToString(currency)}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Price Create(decimal price)
    {
        if (decimal.IsNegative(price))
        {
            throw new ArgumentException("Decimal cannot be negative.", nameof(price));
        }

        return new Price(price);
    }

    public static Price operator +(Price left, Price right)
    {
        return new Price(left.Value + right.Value);
    }

    public static Price operator -(Price left, Price right)
    {
        return new Price(left.Value - right.Value);
    }

    public static Price operator *(Price price, decimal multiplier)
    {
        return new Price(price.Value * multiplier);
    }

    public static Price operator /(Price price, decimal divisor)
    {
        return new Price(price.Value / divisor);
    }
}
