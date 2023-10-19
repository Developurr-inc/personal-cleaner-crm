using Developurr.Orderly.Domain.Vendor.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Vendor.ValueObjects;

public sealed class VendorIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingVendorId_ThenShouldInstantiateVendorId()
    {
        // Act
        var vendorId = VendorId.Generate();

        // Assert
        Assert.NotNull(vendorId);
    }
    
    [Fact]
    public void GivenNothing_WhenCallingFormat_ThenShouldNotBeEmpty()
    {
        // Arrange
        var vendorId = VendorId.Generate();
        
        // Act
        var id = vendorId.Format();
        
        // Assert
        Assert.NotEmpty(id);
    }
}