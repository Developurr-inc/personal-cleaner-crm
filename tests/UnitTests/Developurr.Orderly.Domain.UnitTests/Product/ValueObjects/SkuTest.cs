using Developurr.Orderly.Domain.Product.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.CategoryId;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.PackageId;

namespace Developurr.Orderly.Domain.UnitTests.Product.ValueObjects;

public class SkuTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingSku_ThenShouldInstantiateSku()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var categoryId = CategoryIdFixture.GenerateId();
        var packageId = PackageIdFixture.GenerateId();
    
        // Act
        var sku = Sku.Generate("P", name.Value, categoryId.ToString(), packageId.ToString());

        // Assert
        Assert.NotNull(sku);
    }
}
