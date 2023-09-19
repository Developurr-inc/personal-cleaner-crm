namespace Orderly.Domain.UnitTests.TestUtils.ShippingId;

public sealed class ShippingIdFixture
{
    private static Domain.Shipping.ValueObjects.ShippingId CreateValidShippingId()
    {

        return Domain.Shipping.ValueObjects.ShippingId.Generate();
    }
    
    
    public static Domain.Shipping.ValueObjects.ShippingId CreateShippingId(
        Domain.Shipping.ValueObjects.ShippingId? shippingid = null
    )
    {
        return shippingid ?? CreateValidShippingId();
    }
}