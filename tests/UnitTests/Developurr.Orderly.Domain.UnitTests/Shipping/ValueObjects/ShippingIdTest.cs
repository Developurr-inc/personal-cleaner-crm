using Developurr.Orderly.Domain.Shipping.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Shipping.ValueObjects;

public sealed class ShippingIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingShippingId_ThenShouldInstantiateShippingId()
    {
        // Act
        var shippingId = ShippingId.Generate();

        // Assert
        Assert.NotNull(shippingId);
    }
}
