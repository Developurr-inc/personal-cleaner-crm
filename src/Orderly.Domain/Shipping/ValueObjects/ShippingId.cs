using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Shipping.ValueObjects;

public sealed class ShippingId : Identifier<Guid>
{
    private ShippingId(Guid value)
        : base(value) { }

    public static ShippingId Generate()
    {
        return new ShippingId(Guid.NewGuid());
    }
}
