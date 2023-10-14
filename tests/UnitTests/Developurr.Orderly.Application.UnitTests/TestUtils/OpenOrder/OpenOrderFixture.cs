using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Order.OpenOrder;
using Developurr.Orderly.Domain.Customer;
using Developurr.Orderly.Domain.Order;
using Developurr.Orderly.Domain.SalesConsultant;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Customer;
using Developurr.Orderly.Domain.UnitTests.TestUtils.SalesConsultant;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.OpenOrder;

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