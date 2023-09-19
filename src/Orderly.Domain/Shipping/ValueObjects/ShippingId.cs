using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Shipping.ValueObjects;

public class ShippingId : ValueObject
{
    public Guid Value { get; }
    private ShippingId()
    {
        Value = Guid.NewGuid();
    }

    public static ShippingId Generate()
    {
        return new ShippingId();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}