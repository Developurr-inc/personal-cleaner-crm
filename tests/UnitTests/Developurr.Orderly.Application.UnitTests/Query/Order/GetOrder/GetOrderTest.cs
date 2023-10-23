using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Application.Query.Order.GetOrder;
using Developurr.Orderly.Application.UnitTests.TestUtils.GetOrder;
using Developurr.Orderly.Domain.Order.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Order;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.Query.Order.GetOrder;

public sealed class GetOrderTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingGetOrderUseCase_ThenShouldInstantiateGetOrderUseCase()
    {
        // Arrange
        var orderRepositoryMock = new Mock<IOrderRepository>();

        // Act
        var getOrderUseCase = new GetOrderUseCase(orderRepositoryMock.Object);

        // Assert
        Assert.NotNull(getOrderUseCase);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldExecuteGetOrderUseCase()
    {
        // Arrange
        var useCase = GetOrderFixture.CreateUseCase();
        var input = GetOrderFixture.CreateInput();

        // Act
        var output = await useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallGetByIdAsync()
    {
        // Arrange
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var useCase = new GetOrderUseCase(orderRepositoryMock.Object);
        var input = GetOrderFixture.CreateInput();
        var order = OrderFixture.CreateOrder();

        orderRepositoryMock
            .Setup(x => x.GetByIdAsync(input.OrderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        // Act
        _ = await useCase.Handle(input, CancellationToken.None);

        // Assert
        orderRepositoryMock.Verify(
            x => x.GetByIdAsync(input.OrderId, It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldThrowException()
    {
        // Arrange
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var useCase = new GetOrderUseCase(orderRepositoryMock.Object);
        var input = GetOrderFixture.CreateInput();

        // Act
        var exception = await Record.ExceptionAsync(
            () => useCase.Handle(input, CancellationToken.None)
        );

        // Assert
        Assert.IsType<IdNotFoundException>(exception);
        Assert.Equal("Id not found. (Parameter 'OrderId')", exception.Message);
    }
}
