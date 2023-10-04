namespace Orderly.Domain.UnitTests.TestUtils.ProductId;

public static class ProductIdFixture
{
    public static Domain.Product.ValueObjects.ProductId createProductId()
    {

        return Domain.Product.ValueObjects.ProductId.Generate();
    }
}