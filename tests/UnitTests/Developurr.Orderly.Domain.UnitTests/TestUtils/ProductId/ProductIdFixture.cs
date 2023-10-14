namespace Developurr.Orderly.Domain.UnitTests.TestUtils.ProductId;

public static class ProductIdFixture
{
    public static Developurr.Orderly.Domain.Product.ValueObjects.ProductId createProductId()
    {

        return Developurr.Orderly.Domain.Product.ValueObjects.ProductId.Generate();
    }
}