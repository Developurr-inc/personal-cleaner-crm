using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Customer.DeleteCustomer;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Customer;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.DeleteCustomer;

public static class DeleteCustomerFixture
{
    public static DeleteCustomerUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var input = CreateInput();
        var customer = CustomerFixture.CreateCustomer();
        
        customerRepositoryMock.Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>())).ReturnsAsync(customer);
        
        return new DeleteCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object);
    }

    public static DeleteCustomerInput CreateInput()
    {
        return new DeleteCustomerInput("Customer 1");
    }
}