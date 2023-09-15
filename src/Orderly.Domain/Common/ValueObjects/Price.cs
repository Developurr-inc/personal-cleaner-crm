using Orderly.Domain.SeedWork;
using Orderly.Domain.Common.ValueObjects.Validators;

namespace Orderly.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Value { get; }

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

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
