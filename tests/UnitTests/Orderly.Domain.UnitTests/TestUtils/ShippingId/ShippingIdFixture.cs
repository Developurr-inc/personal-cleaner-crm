namespace Orderly.Domain.UnitTests.TestUtils.ShippingId;

public static class ShippingIdFixture
{
    public static Domain.Shipping.ValueObjects.ShippingId CreateShippingId()
    {

        return Domain.Shipping.ValueObjects.ShippingId.Generate();
    }
}