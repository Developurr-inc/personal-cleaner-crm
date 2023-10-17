using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Query.Order.GetOrder;
using Developurr.Orderly.Domain.Order.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Order;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.GetOrder;

public static class GetOrderFixture
{
    public static GetOrderUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var input = CreateInput();
        var order = OrderFixture.CreateOrder();

        orderRepositoryMock.Setup(x => x.GetByIdAsync(input.OrderId, It.IsAny<CancellationToken>())).ReturnsAsync(order);

        return new GetOrderUseCase(orderRepositoryMock.Object);
    }

    public static GetOrderInput CreateInput()
    {
        return new GetOrderInput("Order 1");
    }
}