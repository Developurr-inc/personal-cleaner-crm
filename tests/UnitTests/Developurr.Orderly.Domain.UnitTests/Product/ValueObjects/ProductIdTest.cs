using Developurr.Orderly.Domain.Product.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Product.ValueObjects;

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
}
