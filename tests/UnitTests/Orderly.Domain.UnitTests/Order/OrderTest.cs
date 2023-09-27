using Orderly.Domain.UnitTests.TestUtils.Order;

namespace Orderly.Domain.UnitTests.Order;

public sealed class OrderTest
{
    [Theory]
    [MemberData(nameof(OrderGenerator.CreateOrders), MemberType = typeof(OrderGenerator))]
    public void GivenValidInput_WhenOpeningOrder_ShouldInstantiateOrder(Domain.Order.Order order)
    {
        // Act
        var newOrder = OrderFixture.CreateOrder();

        // Assert
        OrderAssertion.AssertOrder(order, newOrder);
    }
}
