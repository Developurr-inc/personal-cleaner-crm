using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Application.Query.Vendor.GetVendor;
using Developurr.Orderly.Application.UnitTests.TestUtils.GetVendor;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.Query.Vendor.GetVendor;

public sealed class GetVendorTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingGetVendorUseCase_ThenShouldInstantiateGetVendorUseCase()
    {
        // Arrange
        var vendorRepositoryMock = new Mock<IVendorRepository>();

        // Act
        var getVendorUseCase = new GetVendorUseCase(vendorRepositoryMock.Object);

        // Assert
        Assert.NotNull(getVendorUseCase);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldExecuteGetVendorUseCase()
    {
        // Arrange
        var useCase = GetVendorFixture.CreateUseCase();
        var input = GetVendorFixture.CreateInput();

        // Act
        var output = await useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }

    [Fact]
    public async void GivenValidInput_WhenCallExecute_ThenShouldCallGetByIdAsync()
    {
        // Arrange
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var useCase = new GetVendorUseCase(vendorRepositoryMock.Object);
        var input = GetVendorFixture.CreateInput();
        var vendor = VendorFixture.CreateVendor();

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(vendor);

        // Act
        _ = await useCase.Handle(input, CancellationToken.None);

        // Assert
        vendorRepositoryMock.Verify(
            x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async void GivenInvalidInput_WhenCallExecute_ThenShouldThrowException()
    {
        // Arrange
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var useCase = new GetVendorUseCase(vendorRepositoryMock.Object);
        var input = GetVendorFixture.CreateInput();

        // Act
        var exception = await Record.ExceptionAsync(
            () => useCase.Handle(input, CancellationToken.None)
        );

        // Assert
        Assert.IsType<NotFoundException>(exception);
        Assert.Equal("Id not found. (Parameter 'VendorId')", exception.Message);
    }
}