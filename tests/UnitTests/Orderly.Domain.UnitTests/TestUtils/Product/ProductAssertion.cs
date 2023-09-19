using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Product;

public sealed class ProductAssertion
{
    public static void AssertProduct(Domain.Product.Product expected, Domain.Product.Product actual)
    {
        Assert.NotNull(actual);
        Assert.NotNull(actual.Id);
        Assert.NotEqual(default, actual.Id.Value);
        Assert.Equal(expected.Code, actual.Code);
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Packaging, actual.Packaging);
        Assert.Equal(expected.ExciseTax, actual.ExciseTax);
        Assert.NotEqual(default, actual.CreatedAt);
    }
}