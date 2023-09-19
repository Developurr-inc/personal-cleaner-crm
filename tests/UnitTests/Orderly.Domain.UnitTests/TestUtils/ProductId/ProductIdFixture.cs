namespace Orderly.Domain.UnitTests.TestUtils.ProductId;

public sealed class ProductIdFixture : BaseFixture
{
    private static Domain.Product.ValueObjects.ProductId createValidProductId()
    {

        return Domain.Product.ValueObjects.ProductId.Generate();
    }


    public static Domain.Product.ValueObjects.ProductId CreateProductId(
        Domain.Product.ValueObjects.ProductId? productgid = null
    )
    {
        return productgid ?? createValidProductId();
    }
}