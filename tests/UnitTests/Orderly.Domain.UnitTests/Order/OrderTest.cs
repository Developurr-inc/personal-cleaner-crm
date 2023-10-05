using Orderly.Domain.Exceptions;
using Orderly.Domain.UnitTests.TestUtils.Constants;
using Orderly.Domain.UnitTests.TestUtils.Order;

namespace Orderly.Domain.UnitTests.Order;

public sealed class OrderTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingOrder_ThenShouldInstantiateOrder()
    {
        // Act
        var order = Domain.Order.Order.Open(
            Constants.CustomerId.Id,
            Constants.SalesConsultantId.Id
        );

        // Assert
        Assert.NotNull(order);
    }
}
