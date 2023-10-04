using Orderly.Domain.SalesConsultant.ValueObjects;

namespace Orderly.Domain.UnitTests.SalesConsultant.ValueObjects;

public sealed class SalesConsultantIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingSalesConsultantId_ThenShouldInstantiateSalesConsultantId()
    {
        // Act
        var salesConsultantId = SalesConsultantId.Generate();

        // Assert
        Assert.NotNull(salesConsultantId);
    }
    
    [Fact]
    public void GivenNothing_WhenCallingFormat_ThenShouldNotBeEmpty()
    {
        // Arrange
        var salesConsultantId = SalesConsultantId.Generate();
        
        // Act
        var id = salesConsultantId.Format();
        
        // Assert
        Assert.NotEmpty(id);
    }
}