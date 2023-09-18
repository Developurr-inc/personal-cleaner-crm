namespace Orderly.Domain.UnitTests.TestUtils.ShippingId;

public class ShippingIdAssertion
{
    public static void AssertShippingId(
        Domain.Shipping.ValueObjects.ShippingId actual
    )
    {
        Assert.NotNull(actual);
        Assert.NotNull(actual.Value);
        Assert.NotEqual(actual.Value, default);
    }
}