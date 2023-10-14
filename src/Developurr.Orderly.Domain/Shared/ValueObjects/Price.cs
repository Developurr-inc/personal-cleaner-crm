using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class Price : ValueObject
{
    public readonly decimal Value;

    private Price(decimal price)
    {
        Value = price;
    }

    public static Price Create(decimal price)
    {
        var priceValidator = new PriceValidator(price);
        priceValidator.Validate();

        return new Price(price);
    }

    public string Format()
    {
        const string currency = "N2";
        return $"R$ {Value.ToString(currency)}";
    }

    public override string ToString()
    {
        return Format();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
