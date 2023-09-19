using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Product;

public sealed class ProductGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateProducts()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { ProductFixture.CreateProduct() };
    }

    public static IEnumerable<object[]> CreateInvalidNames()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[] { StringFixture.CreateEmptyString() };
            yield return new object[] { ProductFixture.CreateShortName() };
            yield return new object[] { ProductFixture.CreateLongName() };
        }
    }
}