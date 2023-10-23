using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Order.CloseOrder;
using Developurr.Orderly.Domain.Order.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Order;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.CloseOrder;

public static class CloseOrderFixture
{
    public static CloseOrderUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var input = CreateInput();
        var order = OrderFixture.CreateOrder();

        orderRepositoryMock
            .Setup(x => x.GetByIdAsync(input.OrderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        return new CloseOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object);
    }

    public static CloseOrderInput CreateInput()
    {
        return new CloseOrderInput("Order 1");
    }
}
