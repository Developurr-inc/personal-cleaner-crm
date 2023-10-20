using Developurr.Orderly.Application.Query.Vendor.GetVendor;
using Developurr.Orderly.Domain.Vendor.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.GetVendor;

public static class GetVendorFixture
{
    public static GetVendorUseCase CreateUseCase()
    {
        var vendorRepositoryMock = new Mock<IVendorRepository>();
        var input = CreateInput();
        var vendor = VendorFixture.CreateVendor();
        
        vendorRepositoryMock.Setup(x => x.GetByIdAsync(input.VendorId, It.IsAny<CancellationToken>())).ReturnsAsync(vendor);
        
        return new GetVendorUseCase(vendorRepositoryMock.Object);
    }

    public static GetVendorInput CreateInput()
    {
        return new GetVendorInput("Vendor 1");
    }
}