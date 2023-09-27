namespace Orderly.Domain.UnitTests.TestUtils.ProductId;

public sealed class ProductIdAssertion
{
    public static void AssertProductId(Domain.Product.ValueObjects.ProductId actual)
    {
        Assert.NotNull(actual);
    }
}
