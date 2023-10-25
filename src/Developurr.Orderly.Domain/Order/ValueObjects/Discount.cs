using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Order.ValueObjects;

public sealed class Discount : ValueObject
{
    public readonly decimal Value;

    private Discount() { }

    private Discount(decimal value)
    {
        Value = value;
    }

    public static Discount Create(decimal value)
    {
        if (value is < 0 or > 100)
            throw new ValidationException("Discount value is invalid");

        return new Discount(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}