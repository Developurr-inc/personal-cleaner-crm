using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Customer.DeleteCustomer;
using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Application.UnitTests.TestUtils.DeleteCustomer;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Customer;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.Command.Customer.DeleteCustomer;

public sealed class DeleteCustomerTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingDeleteCustomerUseCase_ThenShouldInstantiateDeleteCustomerUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();

        // Act
        var deleteCustomerUseCase = new DeleteCustomerUseCase(
            unitOfWorkMock.Object,
            customerRepositoryMock.Object
        );

        // Assert
        Assert.NotNull(deleteCustomerUseCase);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldExecuteDeleteCustomerUseCase()
    {
        // Arrange
        var useCase = DeleteCustomerFixture.CreateUseCase();
        var input = DeleteCustomerFixture.CreateInput();

        // Act
        var output = await useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldCallGetByIdAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var useCase = new DeleteCustomerUseCase(
            unitOfWorkMock.Object,
            customerRepositoryMock.Object
        );
        var input = DeleteCustomerFixture.CreateInput();
        var customer = CustomerFixture.CreateCustomer();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        // Act
        _ = await useCase.Handle(input, CancellationToken.None);

        // Assert
        customerRepositoryMock.Verify(
            x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldCallUpdateAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var useCase = new DeleteCustomerUseCase(
            unitOfWorkMock.Object,
            customerRepositoryMock.Object
        );
        var input = DeleteCustomerFixture.CreateInput();
        var customer = CustomerFixture.CreateCustomer();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        // Act
        _ = await useCase.Handle(input, CancellationToken.None);

        // Assert
        customerRepositoryMock.Verify(
            x => x.UpdateAsync(customer, It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var useCase = new DeleteCustomerUseCase(
            unitOfWorkMock.Object,
            customerRepositoryMock.Object
        );
        var input = DeleteCustomerFixture.CreateInput();
        var customer = CustomerFixture.CreateCustomer();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        // Act
        _ = await useCase.Handle(input, CancellationToken.None);

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldHaveDisableCustomer()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var useCase = new DeleteCustomerUseCase(
            unitOfWorkMock.Object,
            customerRepositoryMock.Object
        );
        var input = DeleteCustomerFixture.CreateInput();
        var customer = CustomerFixture.CreateCustomer();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        // Act
        _ = await useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.False(customer.Active.IsActive);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldThrowException()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var useCase = new DeleteCustomerUseCase(
            unitOfWorkMock.Object,
            customerRepositoryMock.Object
        );
        var input = DeleteCustomerFixture.CreateInput();
        var expectedMessage = "Id not found. (Parameter 'CustomerId')";

        // Act
        var exception = await Record.ExceptionAsync(
            () => useCase.Handle(input, CancellationToken.None)
        );

        // Assert
        Assert.IsType<NotFoundException>(exception);
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldNotCallUpdateAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var useCase = new DeleteCustomerUseCase(
            unitOfWorkMock.Object,
            customerRepositoryMock.Object
        );
        var input = DeleteCustomerFixture.CreateInput();
        var customer = CustomerFixture.CreateCustomer();

        // Act
        _ = await Record.ExceptionAsync(() => useCase.Handle(input, CancellationToken.None));

        // Assert
        customerRepositoryMock.Verify(
            x => x.UpdateAsync(customer, It.IsAny<CancellationToken>()),
            Times.Never
        );
    }

    [Fact]
    public async void GivenInvalidInput_WhenCallExecute_ThenShouldCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var useCase = new DeleteCustomerUseCase(
            unitOfWorkMock.Object,
            customerRepositoryMock.Object
        );
        var input = DeleteCustomerFixture.CreateInput();

        // Act
        _ = await Record.ExceptionAsync(() => useCase.Handle(input, CancellationToken.None));

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}