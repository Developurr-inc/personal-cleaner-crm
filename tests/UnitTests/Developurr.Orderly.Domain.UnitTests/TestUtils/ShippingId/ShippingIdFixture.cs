namespace Developurr.Orderly.Domain.UnitTests.TestUtils.ShippingId;

public static class ShippingIdFixture
{
    public static Developurr.Orderly.Domain.Shipping.ValueObjects.ShippingId CreateShippingId()
    {

        return Developurr.Orderly.Domain.Shipping.ValueObjects.ShippingId.Generate();
    }
}