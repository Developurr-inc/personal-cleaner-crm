using Orderly.Domain.Order.ValueObjects;

namespace Orderly.Domain.UnitTests.Order.ValueObjects;

public sealed class OrderIdTest
{
    [Fact]
    public void GivenValidOrderId_WhenGeneratingOrderId_ThenShouldInstantiateOrderId()
    {
        // Act
        var orderId = OrderId.Generate();

        // Assert
        Assert.NotNull(orderId);
    }
}