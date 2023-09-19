using Orderly.Domain.UnitTests.TestUtils.ShippingId;

namespace Orderly.Domain.UnitTests.Shipping.ValueObjects;

public class ShippingIdTest
{
    [Theory]
    [MemberData(nameof(ShippingIdGenerator.CreateShippingIds), MemberType = typeof(ShippingIdGenerator))]
    public void GivenValidInputs_WhenCreatingShippingId_ThenShouldInstantiateShippingId(
        Domain.Shipping.ValueObjects.ShippingId shippingId
    )
    {
        // Act
        var newShippingId = ShippingIdFixture.CreateShippingId(shippingId);

        // Assert
        ShippingIdAssertion.AssertShippingId(newShippingId);
    }
}