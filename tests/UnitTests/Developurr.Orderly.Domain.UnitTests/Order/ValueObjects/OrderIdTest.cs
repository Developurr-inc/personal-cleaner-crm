using Developurr.Orderly.Domain.Order.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Order.ValueObjects;

public sealed class OrderIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingOrderId_ThenShouldInstantiateOrderId()
    {
        // Act
        var orderId = OrderId.Generate();

        // Assert
        Assert.NotNull(orderId);
    }
}
