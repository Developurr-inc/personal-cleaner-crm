using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Product;

public class ProductAssertion
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

    public static void AssertProductException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);

        var entityValidationException = (EntityValidationException)exception;

        Assert.NotEmpty(entityValidationException.Errors);
    }
}