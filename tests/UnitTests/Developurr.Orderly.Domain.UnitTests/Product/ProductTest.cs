using Developurr.Orderly.Domain.UnitTests.TestUtils.CategoryId;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.PackageId;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Price;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Product;

namespace Developurr.Orderly.Domain.UnitTests.Product;

public sealed class ProductTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingProduct_ThenShouldInstantiateProduct()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();
        var categoryId = CategoryIdFixture.GenerateId();
        var packageId = PackageIdFixture.GenerateId();
        var unitPrice = PriceFixture.CreatePrice();
        var tax = PriceFixture.CreatePrice();

        // Act
        var product = Domain.Product.Product.Create(
            name.ToString(),
            description.ToString(),
            categoryId,
            packageId,
            unitPrice.Value,
            tax.Value
        );

        // Assert
        Assert.NotNull(product);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingProduct_ThenShouldHaveValidId()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();
        var categoryId = CategoryIdFixture.GenerateId();
        var packageId = PackageIdFixture.GenerateId();
        var unitPrice = PriceFixture.CreatePrice();
        var tax = PriceFixture.CreatePrice();

        // Act
        var product = Domain.Product.Product.Create(
            name.ToString(),
            description.ToString(),
            categoryId,
            packageId,
            unitPrice.Value,
            tax.Value
        );

        // Assert
        Assert.NotNull(product.Id);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingProduct_ThenShouldHaveValidSku()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();
        var categoryId = CategoryIdFixture.GenerateId();
        var packageId = PackageIdFixture.GenerateId();
        var unitPrice = PriceFixture.CreatePrice();
        var tax = PriceFixture.CreatePrice();

        // Act
        var product = Domain.Product.Product.Create(
            name.ToString(),
            description.ToString(),
            categoryId,
            packageId,
            unitPrice.Value,
            tax.Value
        );

        // Assert
        Assert.NotNull(product.Sku);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingProduct_ThenShouldHaveZeroQuantity()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();
        var categoryId = CategoryIdFixture.GenerateId();
        var packageId = PackageIdFixture.GenerateId();
        var unitPrice = PriceFixture.CreatePrice();
        var tax = PriceFixture.CreatePrice();

        // Act
        var product = Domain.Product.Product.Create(
            name.ToString(),
            description.ToString(),
            categoryId,
            packageId,
            unitPrice.Value,
            tax.Value
        );

        // Assert
        Assert.Equal(0, product.StockItems.Value);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingProduct_ThenShouldHaveActiveStatusTrue()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();
        var categoryId = CategoryIdFixture.GenerateId();
        var packageId = PackageIdFixture.GenerateId();
        var unitPrice = PriceFixture.CreatePrice();
        var tax = PriceFixture.CreatePrice();

        // Act
        var product = Domain.Product.Product.Create(
            name.ToString(),
            description.ToString(),
            categoryId,
            packageId,
            unitPrice.Value,
            tax.Value
        );

        // Assert
        Assert.True(product.Active.IsActive);
    }

    [Fact]
    public void GivenValidProduct_WhenDeactivatingProduct_ThenShouldBeInactive()
    {
        // Arrange
        var product = ProductFixture.CreateProduct();

        // Act
        product.Deactivate();

        // Assert
        Assert.False(product.Active.IsActive);
    }

    [Fact]
    public void GivenValidProduct_WhenAddingItemToInventory_ThenShouldHaveValidQuantity()
    {
        // Arrange
        var product = ProductFixture.CreateProduct();
        var expectedQuantity = 20;

        // Act
        product.AddStockItems(expectedQuantity);

        // Assert
        Assert.Equal(expectedQuantity, product.StockItems.Value);
    }

    [Fact]
    public void GivenValidProduct_WhenRemovingItemFromInventory_ThenShouldHaveValidQuantity()
    {
        // Arrange
        var product = ProductFixture.CreateProduct();
        product.AddStockItems(40);
        var expectedQuantity = 20;

        // Act
        product.RemoveStockItems(20);

        // Assert
        Assert.Equal(expectedQuantity, product.StockItems.Value);
    }
}
