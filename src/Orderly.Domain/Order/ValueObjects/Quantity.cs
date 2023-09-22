using Orderly.Domain.Order.Validators;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order.ValueObjects;

public sealed class Quantity : ValueObject
{
    public readonly int Value;

    private Quantity(int value)
    {
        Value = value;
    }

    public static Quantity Create(int value)
    {
        var quantityValidator = new QuantityValidator(value);
        quantityValidator.Validate();

        return new Quantity(value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
