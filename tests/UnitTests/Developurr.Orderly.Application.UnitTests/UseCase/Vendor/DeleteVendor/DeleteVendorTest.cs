using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Vendor.DeleteVendor;
using Developurr.Orderly.Application.UnitTests.TestUtils.DeleteVendor;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.UseCase.Vendor.DeleteVendor;

public sealed class DeleteVendorTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingDeleteVendorUseCase_ThenShouldInstantiateDeleteVendorUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        
        // Act
        var deleteVendorUseCase = new DeleteVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        
        // Assert
        Assert.NotNull(deleteVendorUseCase);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldExecuteDeleteVendorUseCase()
    {
        // Arrange
        var useCase = DeleteVendorFixture.CreateUseCase();
        var input = DeleteVendorFixture.CreateInput();
        
        // Act
        var output = await useCase.Handle(input, CancellationToken.None);
        
        // Assert
        Assert.NotNull(output);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldCallGetByIdAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var useCase = new DeleteVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        var input = DeleteVendorFixture.CreateInput();
        var vendor = VendorFixture.CreateVendor();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>())).ReturnsAsync(vendor);
        
        // Act
        _ = await useCase.Handle(input, CancellationToken.None);
        
        // Assert
        vendorRepositoryMock.Verify(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldCallUpdateAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var useCase = new DeleteVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        var input = DeleteVendorFixture.CreateInput();
        var vendor = VendorFixture.CreateVendor();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>())).ReturnsAsync(vendor);
        
        // Act
        _ = await useCase.Handle(input, CancellationToken.None);
        
        // Assert
        vendorRepositoryMock.Verify(x => x.UpdateAsync(vendor, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var useCase = new DeleteVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        var input = DeleteVendorFixture.CreateInput();
        var vendor = VendorFixture.CreateVendor();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>())).ReturnsAsync(vendor);
        
        // Act
        _ = await useCase.Handle(input, CancellationToken.None);
        
        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldHaveDisableVendor()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var useCase = new DeleteVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        var input = DeleteVendorFixture.CreateInput();
        var vendor = VendorFixture.CreateVendor();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>())).ReturnsAsync(vendor);
        
        // Act
        _ = await useCase.Handle(input, CancellationToken.None);
        
        // Assert
        Assert.False(vendor.Active);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldThrowException()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var useCase = new DeleteVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        var input = DeleteVendorFixture.CreateInput();
        
        // Act
        var exception = await Record.ExceptionAsync(() => useCase.Handle(input, CancellationToken.None));
        
        // Assert
        Assert.IsType<ArgumentException>(exception);
        Assert.Equal("Vendor not found. (Parameter 'VendorId')", exception.Message);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldNotCallUpdateAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var useCase = new DeleteVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        var input = DeleteVendorFixture.CreateInput();
        var vendor = VendorFixture.CreateVendor();
        
        // Act
        _ = await Record.ExceptionAsync(() => useCase.Handle(input, CancellationToken.None));
        
        // Assert
        vendorRepositoryMock.Verify(x => x.UpdateAsync(vendor, It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async void GivenInvalidInput_WhenCallExecute_ThenShouldCallCommitAsync()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var useCase = new DeleteVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
        var input = DeleteVendorFixture.CreateInput();
        
        // Act
        _ = await Record.ExceptionAsync(() => useCase.Handle(input, CancellationToken.None));
        
        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}