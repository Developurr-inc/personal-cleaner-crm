using Developurr.Orderly.Domain.Order.Enums;
using Developurr.Orderly.Domain.UnitTests.TestUtils.CustomerId;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Order;
using Developurr.Orderly.Domain.UnitTests.TestUtils.VendorId;

namespace Developurr.Orderly.Domain.UnitTests.Order;

public sealed class OrderTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingOrder_ThenShouldInstantiateOrder()
    {
        // Arrange
        var customerId = CustomerIdFixture.GenerateId();
        var vendorId = VendorIdFixture.GenerateId();

        // Act
        var order = Domain.Order.Order.Open(customerId, vendorId);

        // Assert
        Assert.NotNull(order);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingOrder_ThenShouldHaveValidId()
    {
        // Arrange
        var customerId = CustomerIdFixture.GenerateId();
        var vendorId = VendorIdFixture.GenerateId();

        // Act
        var order = Domain.Order.Order.Open(customerId, vendorId);

        // Assert
        Assert.NotNull(order.Id);
    }

    [Fact]
    public void GivenValidInput_WhenDeletingOrder_ThenShouldHaveStatusDeactivated()
    {
        // Arrange
        var order = OrderFixture.CreateOrder();

        // Act
        order.Deactivate();

        // Assert
        Assert.False(order.Active.IsActive);
    }

    [Fact]
    public void GivenValidInput_WhenClosingOrder_ThenShouldHaveStatusClosed()
    {
        // Arrange
        var order = OrderFixture.CreateOrder();

        // Act
        order.Close();

        // Assert
        Assert.Equal(Status.Closed, order.Status);
    }
}
