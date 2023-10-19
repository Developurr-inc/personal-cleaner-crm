using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Customer.CreateCustomer;
using Developurr.Orderly.Application.UnitTests.TestUtils.CreateCustomer;
using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.UseCase.Customer.CreateCustomer;

public class CreateCustomerTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingCreateCustomerUseCase_ThenShouldInstantiateCreateCustomerUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();

        // Act
        var createCustomerUseCase = new CreateCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object, vendorRepositoryMock.Object);

        // Assert
        Assert.NotNull(createCustomerUseCase);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallInsertAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var createCustomerUseCase = new CreateCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object, vendorRepositoryMock.Object);
        var input = CreateCustomerFixture.CreateInput();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(VendorFixture.CreateVendor());
        
        // Act
        _ = await createCustomerUseCase.Handle(input, CancellationToken.None);
        
        // Assert
        customerRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Customer.Customer>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallCommitAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var createCustomerUseCase = new CreateCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object, vendorRepositoryMock.Object);
        var input = CreateCustomerFixture.CreateInput();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(VendorFixture.CreateVendor());
        
        // Act
        _ = await createCustomerUseCase.Handle(input, CancellationToken.None);
        
        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallVendorGetByIdAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var createCustomerUseCase = new CreateCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object, vendorRepositoryMock.Object);
        var input = CreateCustomerFixture.CreateInput();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(VendorFixture.CreateVendor());

        // Act
        _ = await createCustomerUseCase.Handle(input, CancellationToken.None);
        
        // Assert
        vendorRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<string>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnValidOutput()
    {
        // Arrange
        var createCustomerUseCase = CreateCustomerFixture.CreateUseCase();
        var input = CreateCustomerFixture.CreateInput();

        // Act
        var output = await createCustomerUseCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnOutput()
    {
        // Arrange
        var createCustomerUseCase = CreateCustomerFixture.CreateUseCase();
        var input = CreateCustomerFixture.CreateInput();

        // Act
        var output = await createCustomerUseCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotEmpty(output.CustomerId);
    }
    
    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldReturnDomainValidationExceptionWithMessage()
    {
        // Arrange
        var createCustomerUseCase = CreateCustomerFixture.CreateUseCase();
        var input = CreateCustomerFixture.CreateInvalidInput();
        
        // Act
        var exception = await Record.ExceptionAsync(() => createCustomerUseCase.Handle(input, CancellationToken.None));
    
        // Assert
        var entityValidationException = Assert.IsType<EntityValidationException>(exception);
        Assert.NotEmpty(entityValidationException.Errors);
    }
}