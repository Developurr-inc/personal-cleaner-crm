using Moq;
using Orderly.Application.Command;
using Orderly.Application.Command.Order.OpenOrder;
using Orderly.Application.UnitTests.TestUtils.OpenOrder;
using Orderly.Domain.Customer;
using Orderly.Domain.Order;
using Orderly.Domain.SalesConsultant;
using Orderly.Domain.UnitTests.TestUtils.Customer;
using Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

namespace Orderly.Application.UnitTests.UseCase.Order.OpenOrder;

public class OpenOrderTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingOpenOrderUseCase_ThenShouldInstantiateOpenOrderUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        // Act
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object,customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);

        // Assert
        Assert.NotNull(openOrderUseCase);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallCustomerGetByIdAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = OpenOrderFixture.OpenInput();

        customerRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(CustomerFixture.CreateCustomer());
        
        salesConsultantRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(SalesConsultantFixture.CreateSalesConsultant());

        // Act
        _ = await openOrderUseCase.Execute(input, CancellationToken.None);
        
        // Assert
        customerRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<string>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallSalesConsultantGetByIdAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = OpenOrderFixture.OpenInput();

        customerRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(CustomerFixture.CreateCustomer());
        
        salesConsultantRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(SalesConsultantFixture.CreateSalesConsultant());

        // Act
        _ = await openOrderUseCase.Execute(input, CancellationToken.None);
        
        // Assert
        salesConsultantRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<string>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallInsertAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = OpenOrderFixture.OpenInput();
        
        customerRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(CustomerFixture.CreateCustomer());
        
        salesConsultantRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(SalesConsultantFixture.CreateSalesConsultant());

        // Act
        _ = await openOrderUseCase.Execute(input, CancellationToken.None);
        
        // Assert
        orderRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Order.Order>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallCommitAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = OpenOrderFixture.OpenInput();
        
        customerRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(CustomerFixture.CreateCustomer());
        
        salesConsultantRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(SalesConsultantFixture.CreateSalesConsultant());
        
        // Act
        _ = await openOrderUseCase.Execute(input, CancellationToken.None);
        
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
        var output = await openOrderUseCase.Execute(input, CancellationToken.None);

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
        var output = await openOrderUseCase.Execute(input, CancellationToken.None);

        // Assert
        Assert.NotEmpty(output.OrderId);
    }
    
    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldReturnDomainValidationExceptionWithMessage()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = OpenOrderFixture.OpenInput();
        
        // Act
        var exception = await Record.ExceptionAsync(() => openOrderUseCase.Execute(input, CancellationToken.None));
    
        // Assert
        _ = Assert.IsType<Exception>(exception);
        //Assert.NotEmpty(entityValidationException.Errors);
    }
    
    [Fact]
    public async void GivenInvalidSalesConsultant_WhenCallingExecute_ThenShouldNotCallOrderInsertAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = OpenOrderFixture.OpenInput();
        
        customerRepositoryMock.Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>())).ReturnsAsync(CustomerFixture.CreateCustomer());

        // Act
        _ = await Record.ExceptionAsync(() => openOrderUseCase.Execute(input, CancellationToken.None));

        // Assert
        orderRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Order.Order>(), It.IsAny<CancellationToken>()), Times.Never);
    }
    
    [Fact]
    public async void GivenInvalidSalesConsultant_WhenCallingExecute_ThenShouldNotCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = OpenOrderFixture.OpenInput();
        
        customerRepositoryMock.Setup(x => x.GetByIdAsync(input.CustomerId, It.IsAny<CancellationToken>())).ReturnsAsync(CustomerFixture.CreateCustomer());

        // Act
        _ = await Record.ExceptionAsync(() => openOrderUseCase.Execute(input, CancellationToken.None));

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
    
    [Fact]
    public async void GivenInvalidCustomer_WhenCallingExecute_ThenShouldNotCallOrderInsertAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = OpenOrderFixture.OpenInput();
        
        salesConsultantRepositoryMock.Setup(x => x.GetByIdAsync(input.SalesConsultantId, It.IsAny<CancellationToken>())).ReturnsAsync(SalesConsultantFixture.CreateSalesConsultant());

        // Act
        _ = await Record.ExceptionAsync(() => openOrderUseCase.Execute(input, CancellationToken.None));

        // Assert
        orderRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Order.Order>(), It.IsAny<CancellationToken>()), Times.Never);
    }
    
    [Fact]
    public async void GivenInvalidCustomer_WhenCallingExecute_ThenShouldNotCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var orderRepositoryMock = new Mock<IOrderRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        
        var openOrderUseCase = new OpenOrderUseCase(unitOfWorkMock.Object, orderRepositoryMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = OpenOrderFixture.OpenInput();
        
        salesConsultantRepositoryMock.Setup(x => x.GetByIdAsync(input.SalesConsultantId, It.IsAny<CancellationToken>())).ReturnsAsync(SalesConsultantFixture.CreateSalesConsultant());

        // Act
        _ = await Record.ExceptionAsync(() => openOrderUseCase.Execute(input, CancellationToken.None));

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync( It.IsAny<CancellationToken>()), Times.Never);
    }
    
}