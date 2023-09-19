using Orderly.Domain.UnitTests.TestUtils;
using Orderly.Domain.UnitTests.TestUtils.Product;

namespace Orderly.Domain.UnitTests.Product;

public class ProductTest
{
    [Theory]
    [MemberData(nameof(ProductGenerator.CreateProducts), MemberType = typeof(ProductGenerator))]
    public void GivenValidInput_WhenCreatingProduct_ThenShouldInstantiateProduct(
        Domain.Product.Product product
    )
    {
        // Act
        var newProduct = ProductFixture.CreateProduct(product);

        // Assert
        ProductAssertion.AssertProduct(product, newProduct);
    }

    [Theory]
    [MemberData(nameof(ProductGenerator.CreateInvalidNames), MemberType = typeof(ProductGenerator))]
    public void GivenInvalidName_WhenCreatingProduct_ThenShouldThrowException(string invalidName)
    {
        // Arrange
        void Action()
        {
            _ = ProductFixture.CreateProduct(name: invalidName);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        BaseAssertion.AssertException(exception!);
    }
}