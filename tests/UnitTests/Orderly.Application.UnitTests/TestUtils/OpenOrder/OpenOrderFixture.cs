using Moq;
using Orderly.Application.Command;
using Orderly.Application.Command.Order.OpenOrder;
using Orderly.Domain.Customer;
using Orderly.Domain.UnitTests.TestUtils.Constants;
using Orderly.Domain.Order;
using Orderly.Domain.SalesConsultant;
using Orderly.Domain.UnitTests.TestUtils.Customer;
using Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

namespace Orderly.Application.UnitTests.TestUtils.OpenOrder;

public static class OpenOrderFixture
{
    public static OpenOrderUseCase OpenUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        
        customerRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(CustomerFixture.CreateCustomer());

        
        salesConsultantRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(SalesConsultantFixture.CreateSalesConsultant());
        
        return new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
    }
    
    public static OpenOrderInput OpenInput()
    {
        return new OpenOrderInput(
            Constants.CustomerId.Id.Format(),
            Constants.SalesConsultantId.Id.Format()
        );
    }
    
}