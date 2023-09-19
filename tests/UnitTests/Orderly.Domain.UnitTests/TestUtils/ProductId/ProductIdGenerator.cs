namespace Orderly.Domain.UnitTests.TestUtils.ProductId;

public class ProductIdGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateProductIds()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { ProductIdFixture.CreateProductId() };
    }
}