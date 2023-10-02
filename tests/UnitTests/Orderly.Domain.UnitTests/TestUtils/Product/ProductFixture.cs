using System.Runtime.InteropServices.JavaScript;
using Orderly.Domain.Product.Validators;
using Orderly.Domain.UnitTests.TestUtils.Price;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Product;

public static class ProductFixture
{
    public static Domain.Product.Product CreateProduct()
    {
        return Domain.Product.Product.Create(
            Constants.Constants.Product.Code,
            Constants.Constants.Product.Name,
            Constants.Constants.Product.Packaging,
            Constants.Constants.Product.ExciseTax,
            Constants.Constants.Product.PriceValue);
    }
}
