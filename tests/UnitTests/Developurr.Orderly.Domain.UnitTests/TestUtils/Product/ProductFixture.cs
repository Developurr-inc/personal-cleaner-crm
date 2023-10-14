namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Product;

public static class ProductFixture
{
    public static Developurr.Orderly.Domain.Product.Product CreateProduct()
    {
        return Developurr.Orderly.Domain.Product.Product.Create(
            Constants.Constants.Product.Code,
            Constants.Constants.Product.Name,
            Constants.Constants.Product.Packaging,
            Constants.Constants.Product.ExciseTax,
            Constants.Constants.Product.PriceValue);
    }
}
