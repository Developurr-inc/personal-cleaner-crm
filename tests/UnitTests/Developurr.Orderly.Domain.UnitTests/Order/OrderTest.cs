using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Order;

public sealed class OrderTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingOrder_ThenShouldInstantiateOrder()
    {
        // Act
        var order = Developurr.Orderly.Domain.Order.Order.Open(
            Constants.CustomerId.Id,
            Constants.SalesConsultantId.Id
        );

        // Assert
        Assert.NotNull(order);
    }
}
