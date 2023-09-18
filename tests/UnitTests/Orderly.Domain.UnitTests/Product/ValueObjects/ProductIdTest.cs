using Orderly.Domain.UnitTests.TestUtils.ProductId;

namespace Orderly.Domain.UnitTests.Product.ValueObjects;

public class ProductIdTest
{
    [Theory]
    [MemberData(nameof(ProductIdGenerator.CreateProductIds), MemberType = typeof(ProductIdGenerator))]
    public void GivenValidInput_WhenGeneratingProductId_ThenShouldInstantiateProductId(
        Domain.Product.ValueObjects.ProductId productId
    )
    {
        // Act
        var newProductId = ProductIdFixture.CreateProductId(productId);
        
        //Assert
        ProductIdAssertion.AssertProductId(productId);
    }
}