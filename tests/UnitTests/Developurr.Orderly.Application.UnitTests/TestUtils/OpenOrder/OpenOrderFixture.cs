using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Order.OpenOrder;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.Order.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Customer;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.OpenOrder;

public static class OpenOrderFixture
{
    public static OpenOrderUseCase OpenUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerFixture.CreateCustomer());

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(VendorFixture.CreateVendor());

        return new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
    }

    public static OpenOrderInput OpenInput()
    {
        return new OpenOrderInput(Constants.CustomerId.Id.ToString(), Constants.VendorId.Id.ToString());
    }
}
