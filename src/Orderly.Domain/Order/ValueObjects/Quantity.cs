using Orderly.Domain.Order.Validators;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order.ValueObjects;

public sealed class Quantity : ValueObject
{
    public int Value { get; private set; }
    
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
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}