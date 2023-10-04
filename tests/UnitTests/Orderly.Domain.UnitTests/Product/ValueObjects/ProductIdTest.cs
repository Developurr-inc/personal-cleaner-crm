using Orderly.Domain.Product.ValueObjects;

namespace Orderly.Domain.UnitTests.Product.ValueObjects;

public sealed class ProductIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingProductId_ThenShouldInstantiateProductId()
    {
        // Act
        var productId = ProductId.Generate();

        // Assert
        Assert.NotNull(productId);
    }
    
    [Fact]
    public void GivenNothing_WhenCallingFormat_ThenShouldNotBeEmpty()
    {
        // Arrange
        var productId = ProductId.Generate();
        
        // Act
        var id = productId.Format();
        
        // Assert
        Assert.NotEmpty(id);
    }
}