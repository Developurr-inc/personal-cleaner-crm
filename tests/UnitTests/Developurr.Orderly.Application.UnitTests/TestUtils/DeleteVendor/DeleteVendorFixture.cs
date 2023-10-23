using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Vendor.DeleteVendor;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.DeleteVendor;

public static class DeleteVendorFixture
{
    public static DeleteVendorUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var input = CreateInput();
        var vendor = VendorFixture.CreateVendor();

        vendorRepositoryMock
            .Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(vendor);

        return new DeleteVendorUseCase(unitOfWorkMock.Object, vendorRepositoryMock.Object);
    }

    public static DeleteVendorInput CreateInput()
    {
        return new DeleteVendorInput("Vendor 1");
    }
}
