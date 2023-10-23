namespace Developurr.Orderly.Domain.UnitTests.TestUtils.ProductId;

public static class ProductIdFixture
{
    public static Domain.Product.ValueObjects.ProductId GenerateId()
    {
        return Domain.Product.ValueObjects.ProductId.Generate();
    }
}
