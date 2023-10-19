using Developurr.Orderly.Domain.Vendor.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Vendor.ValueObjects;

public sealed class SalesConsultantIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingSalesConsultantId_ThenShouldInstantiateSalesConsultantId()
    {
        // Act
        var salesConsultantId = VendorId.Generate();

        // Assert
        Assert.NotNull(salesConsultantId);
    }
    
    [Fact]
    public void GivenNothing_WhenCallingFormat_ThenShouldNotBeEmpty()
    {
        // Arrange
        var salesConsultantId = VendorId.Generate();
        
        // Act
        var id = salesConsultantId.Format();
        
        // Assert
        Assert.NotEmpty(id);
    }
}