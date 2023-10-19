using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Vendor.CreateVendor;
using Developurr.Orderly.Application.UnitTests.TestUtils.CreateVendor;
using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.UseCase.Vendor.CreateVendor;

public class CreateVendorTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingCreateVendorUseCase_ThenShouldInstantiateCreateVendorUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();

        // Act
        var createVendorUseCase = new CreateVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);

        // Assert
        Assert.NotNull(createVendorUseCase);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallInsertAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var createVendorUseCase = new CreateVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        var input = CreateVendorFixture.CreateInput();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(VendorFixture.CreateVendor());
        
        // Act
        _ = await createVendorUseCase.Handle(input, CancellationToken.None);
        
        // Assert
        vendorRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Vendor.Vendor>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallCommitAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var createVendorUseCase = new CreateVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        var input = CreateVendorFixture.CreateInput();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(VendorFixture.CreateVendor());
        
        // Act
        _ = await createVendorUseCase.Handle(input, CancellationToken.None);
        
        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnValidOutput()
    {
        // Arrange
        var createVendorUseCase = CreateVendorFixture.CreateUseCase();
        var input = CreateVendorFixture.CreateInput();

        // Act
        var output = await createVendorUseCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnOutput()
    {
        // Arrange
        var createVendorUseCase = CreateVendorFixture.CreateUseCase();
        var input = CreateVendorFixture.CreateInput();

        // Act
        var output = await createVendorUseCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotEmpty(output.VendorId);
    }
    
    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldReturnDomainValidationExceptionWithMessage()
    {
        // Arrange
        var createVendorUseCase = CreateVendorFixture.CreateUseCase();
        var input = CreateVendorFixture.CreateInvalidInput();
        
        // Act
        var exception = await Record.ExceptionAsync(() => createVendorUseCase.Handle(input, CancellationToken.None));
    
        // Assert
        var entityValidationException = Assert.IsType<EntityValidationException>(exception);
        Assert.NotEmpty(entityValidationException.Errors);
    }
}