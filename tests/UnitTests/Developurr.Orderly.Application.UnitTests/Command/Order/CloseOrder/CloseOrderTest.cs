using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Order.CloseOrder;
using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Application.UnitTests.TestUtils.CloseOrder;
using Developurr.Orderly.Domain.Order.Enums;
using Developurr.Orderly.Domain.Order.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Order;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.Command.Order.CloseOrder;

public sealed class CloseOrderTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingCloseOrderUseCase_ThenShouldInstantiateCloseOrderUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();

        // Act
        var closeOrderUseCase = new CloseOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object
        );

        // Assert
        Assert.NotNull(closeOrderUseCase);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldExecuteCloseOrderUseCase()
    {
        // Arrange
        var useCase = CloseOrderFixture.CreateUseCase();
        var input = CloseOrderFixture.CreateInput();

        // Act
        var output = await useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallGetByIdAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var useCase = new CloseOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object);
        var input = CloseOrderFixture.CreateInput();
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
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallUpdateAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var useCase = new CloseOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object);
        var input = CloseOrderFixture.CreateInput();
        var order = OrderFixture.CreateOrder();

        orderRepositoryMock
            .Setup(x => x.GetByIdAsync(input.OrderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        // Act
        _ = await useCase.Handle(input, CancellationToken.None);

        // Assert
        orderRepositoryMock.Verify(
            x => x.UpdateAsync(order, It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var useCase = new CloseOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object);
        var input = CloseOrderFixture.CreateInput();
        var order = OrderFixture.CreateOrder();

        orderRepositoryMock
            .Setup(x => x.GetByIdAsync(input.OrderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        // Act
        _ = await useCase.Handle(input, CancellationToken.None);

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldHaveClosedOrder()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var useCase = new CloseOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object);
        var input = CloseOrderFixture.CreateInput();
        var order = OrderFixture.CreateOrder();

        orderRepositoryMock
            .Setup(x => x.GetByIdAsync(input.OrderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        // Act
        _ = await useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.True(order.Status == Status.Closed);
    }

    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldThrowException()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var useCase = new CloseOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object);
        var input = CloseOrderFixture.CreateInput();

        // Act
        var exception = await Record.ExceptionAsync(
            () => useCase.Handle(input, CancellationToken.None)
        );

        // Assert
        Assert.IsType<NotFoundException>(exception);
        Assert.Equal("Id not found. (Parameter 'OrderId')", exception.Message);
    }

    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldNotCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var useCase = new CloseOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object);
        var input = CloseOrderFixture.CreateInput();

        // Act
        _ = await Record.ExceptionAsync(() => useCase.Handle(input, CancellationToken.None));

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldNotCallUpdateAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var useCase = new CloseOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object);
        var input = CloseOrderFixture.CreateInput();
        var order = OrderFixture.CreateOrder();

        // Act
        _ = await Record.ExceptionAsync(() => useCase.Handle(input, CancellationToken.None));

        // Assert
        orderRepositoryMock.Verify(
            x => x.UpdateAsync(order, It.IsAny<CancellationToken>()),
            Times.Never
        );
    }
}