namespace Orderly.Domain.UnitTests.TestUtils.ProductId;

public class ProductIdAssertion
{
    public static void AssertProductId(
        Domain.Product.ValueObjects.ProductId actual
    )
    {
        Assert.NotNull(actual);
        Assert.NotNull(actual.Value);
        Assert.NotEqual(actual.Value, default);
    }
}