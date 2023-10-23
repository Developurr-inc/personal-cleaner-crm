using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Application.Query.Customer.GetCustomer;
using Developurr.Orderly.Application.UnitTests.TestUtils.GetCustomer;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Customer;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.Query.Customer.GetCustomer;

public sealed class GetCustomerTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingGetCustomerUseCase_ThenShouldInstantiateGetCustomerUseCase()
    {
        // Arrange
        var customerRepositoryMock = new Mock<ICustomerRepository>();

        // Act
        var getCustomerUseCase = new GetCustomerUseCase(customerRepositoryMock.Object);

        // Assert
        Assert.NotNull(getCustomerUseCase);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldExecuteGetCustomerUseCase()
    {
        // Arrange
        var useCase = GetCustomerFixture.CreateUseCase();
        var input = GetCustomerFixture.CreateInput();

        // Act
        var output = await useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldCallGetByIdAsync()
    {
        // Arrange
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var useCase = new GetCustomerUseCase(customerRepositoryMock.Object);
        var input = GetCustomerFixture.CreateInput();
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
    public async void GivenInvalidInput_WhenCallExecute_ThenShouldThrowException()
    {
        // Arrange
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var useCase = new GetCustomerUseCase(customerRepositoryMock.Object);
        var input = GetCustomerFixture.CreateInput();

        // Act
        var exception = await Record.ExceptionAsync(
            () => useCase.Handle(input, CancellationToken.None)
        );

        // Assert
        Assert.IsType<IdNotFoundException>(exception);
        Assert.Equal("Id not found. (Parameter 'CustomerId')", exception.Message);
    }
}
