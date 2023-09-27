using Orderly.Domain.Order.Validators;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order.ValueObjects;

public sealed class Discount : ValueObject
{
    public readonly decimal Value;

    private Discount(decimal value)
    {
        Value = value;
    }

    public static Discount Create(decimal value)
    {
        var discountValidator = new DiscountValidator(value);
        discountValidator.Validate();

        return new Discount(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
