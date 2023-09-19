using System.Runtime.InteropServices.JavaScript;
using Orderly.Domain.Product.Validators;
using Orderly.Domain.UnitTests.TestUtils.Price;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Product;

public class ProductFixture : BaseFixture
{
    private static Domain.Product.Product CreateValidProduct()
    {

        var price = Faker.Random.Decimal(0, 100);
        var code = StringFixture.CreateString(5, 255);
        var packaging = StringFixture.CreateString(5, 255);
        var exciseTax = Faker.Random.Decimal(0, 100);

        var name = StringFixture.CreateString(
            ProductValidator.NameMinLength,
            ProductValidator.NameMaxLength
        );
    
        return Domain.Product.Product.Create(code, name, packaging, exciseTax, price);
    }
    
    public static Domain.Product.Product CreateProduct(
        Domain.Product.Product? product = null,
        string? name = null,
        decimal? price = null
    )
    {
        var lProduct = product ?? CreateValidProduct();

        return Domain.Product.Product.Create(
            lProduct.Code,
            name ?? lProduct.Name,
            lProduct.Packaging,
            lProduct.ExciseTax,
            price ?? lProduct.Price.Value
        );
    }
    
    public static string CreateShortName()
    {
        return StringFixture.CreateString(1, ProductValidator.NameMinLength - 1);
    }

    public static string CreateLongName()
    {
        return StringFixture.CreateString(ProductValidator.NameMaxLength + 1, 1_000);
    }
}