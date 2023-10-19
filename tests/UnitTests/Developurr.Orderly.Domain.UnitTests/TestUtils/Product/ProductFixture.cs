using Developurr.Orderly.Domain.UnitTests.TestUtils.CategoryId;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.PackageId;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Price;

namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Product;

public static class ProductFixture
{
    public static Developurr.Orderly.Domain.Product.Product CreateProduct()
    {
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();
        var categoryId = CategoryIdFixture.GenerateId();
        var packageId = PackageIdFixture.GenerateId();
        var unitPrice = PriceFixture.CreatePrice();
        var imposto = PriceFixture.CreatePrice();
        
        return Developurr.Orderly.Domain.Product.Product.Create(name, description, categoryId, packageId, unitPrice.Value, imposto.Value);
    }
}
