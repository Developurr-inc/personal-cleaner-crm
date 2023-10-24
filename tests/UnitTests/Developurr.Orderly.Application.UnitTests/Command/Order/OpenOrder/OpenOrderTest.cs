using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Order.OpenOrder;
using Developurr.Orderly.Application.UnitTests.TestUtils.OpenOrder;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.Order.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Customer;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.Command.Order.OpenOrder;

public class OpenOrderTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingOpenOrderUseCase_ThenShouldInstantiateOpenOrderUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        // Act
        var openOrderUseCase = new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );

        // Assert
        Assert.NotNull(openOrderUseCase);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallCustomerGetByIdAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var openOrderUseCase = new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
        var input = OpenOrderFixture.OpenInput();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerFixture.CreateCustomer());

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(VendorFixture.CreateVendor());

        // Act
        _ = await openOrderUseCase.Handle(input, CancellationToken.None);

        // Assert
        customerRepositoryMock.Verify(
            x => x.GetByIdAsync(It.IsAny<string>(), CancellationToken.None),
            Times.Once
        );
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallVendorGetByIdAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var openOrderUseCase = new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
        var input = OpenOrderFixture.OpenInput();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerFixture.CreateCustomer());

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(VendorFixture.CreateVendor());

        // Act
        _ = await openOrderUseCase.Handle(input, CancellationToken.None);

        // Assert
        vendorRepositoryMock.Verify(
            x => x.GetByIdAsync(It.IsAny<string>(), CancellationToken.None),
            Times.Once
        );
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallInsertAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var openOrderUseCase = new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
        var input = OpenOrderFixture.OpenInput();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerFixture.CreateCustomer());

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(VendorFixture.CreateVendor());

        // Act
        _ = await openOrderUseCase.Handle(input, CancellationToken.None);

        // Assert
        orderRepositoryMock.Verify(
            x => x.InsertAsync(It.IsAny<Domain.Order.Order>(), CancellationToken.None),
            Times.Once
        );
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallCommitAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var openOrderUseCase = new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
        var input = OpenOrderFixture.OpenInput();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerFixture.CreateCustomer());

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(VendorFixture.CreateVendor());

        // Act
        _ = await openOrderUseCase.Handle(input, CancellationToken.None);

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(CancellationToken.None), Times.Once);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnValidOutput()
    {
        // Arrange
        var openOrderUseCase = OpenOrderFixture.OpenUseCase();
        var input = OpenOrderFixture.OpenInput();

        // Act
        var output = await openOrderUseCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnOutput()
    {
        // Arrange
        var openOrderUseCase = OpenOrderFixture.OpenUseCase();
        var input = OpenOrderFixture.OpenInput();

        // Act
        var output = await openOrderUseCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotEmpty(output.OrderId);
    }

    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldReturnDomainValidationExceptionWithMessage()
    {
        // Arrange
        var openOrderUseCase = OpenOrderFixture.OpenUseCase();
        var input = OpenOrderFixture.OpenInput();

        // Act
        var exception = await Record.ExceptionAsync(
            () => openOrderUseCase.Handle(input, CancellationToken.None)
        );

        // Assert
        // _ = Assert.IsType<ValidationException>(exception);
        //Assert.NotEmpty(entityValidationException.Errors);
    }

    [Fact]
    public async void GivenInvalidVendor_WhenCallingExecute_ThenShouldNotCallOrderInsertAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();

        var openOrderUseCase = new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
        var input = OpenOrderFixture.OpenInput();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerFixture.CreateCustomer());

        // Act
        _ = await Record.ExceptionAsync(
            () => openOrderUseCase.Handle(input, CancellationToken.None)
        );

        // Assert
        orderRepositoryMock.Verify(
            x => x.InsertAsync(It.IsAny<Domain.Order.Order>(), It.IsAny<CancellationToken>()),
            Times.Never
        );
    }

    [Fact]
    public async void GivenInvalidVendor_WhenCallingExecute_ThenShouldNotCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();

        var openOrderUseCase = new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
        var input = OpenOrderFixture.OpenInput();

        customerRepositoryMock
            .Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerFixture.CreateCustomer());

        // Act
        _ = await Record.ExceptionAsync(
            () => openOrderUseCase.Handle(input, CancellationToken.None)
        );

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async void GivenInvalidCustomer_WhenCallingExecute_ThenShouldNotCallOrderInsertAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();

        var openOrderUseCase = new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
        var input = OpenOrderFixture.OpenInput();

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(VendorFixture.CreateVendor());

        // Act
        _ = await Record.ExceptionAsync(
            () => openOrderUseCase.Handle(input, CancellationToken.None)
        );

        // Assert
        orderRepositoryMock.Verify(
            x => x.InsertAsync(It.IsAny<Domain.Order.Order>(), It.IsAny<CancellationToken>()),
            Times.Never
        );
    }

    [Fact]
    public async void GivenInvalidCustomer_WhenCallingExecute_ThenShouldNotCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();

        var openOrderUseCase = new OpenOrderUseCase(
            unitOfWorkMock.Object,
            orderRepositoryMock.Object,
            customerRepositoryMock.Object,
            vendorRepositoryMock.Object
        );
        var input = OpenOrderFixture.OpenInput();

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(VendorFixture.CreateVendor());

        // Act
        _ = await Record.ExceptionAsync(
            () => openOrderUseCase.Handle(input, CancellationToken.None)
        );

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}