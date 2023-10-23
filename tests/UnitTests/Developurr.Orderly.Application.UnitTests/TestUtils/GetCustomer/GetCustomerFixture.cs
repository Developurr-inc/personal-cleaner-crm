using Developurr.Orderly.Application.Query.Customer.GetCustomer;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Customer;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.GetCustomer;

public static class GetCustomerFixture
{
    public static GetCustomerUseCase CreateUseCase()
    {
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var input = CreateInput();
        var customer = CustomerFixture.CreateCustomer();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        return new GetCustomerUseCase(customerRepositoryMock.Object);
    }

    public static GetCustomerInput CreateInput()
    {
        return new GetCustomerInput("Customer 1");
    }
}
