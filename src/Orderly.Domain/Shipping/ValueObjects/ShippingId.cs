using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Shipping.ValueObjects;

public sealed class ShippingId : ValueObject
{
    public Guid Value { get; }
    private ShippingId(Guid value)
    {
        Value = value;
    }

    public static ShippingId Generate()
    {
        var guid = Guid.NewGuid();
        return new ShippingId(guid);
    }
    
    public static ShippingId Restore(string value)
    {
        var guid = Guid.Parse(value);
        return new ShippingId(guid);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}