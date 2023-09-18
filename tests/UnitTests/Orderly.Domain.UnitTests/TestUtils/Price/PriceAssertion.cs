using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Price;

public static class PriceAssertion
{
    public static void AssertPrice(
        Domain.Common.ValueObjects.Price expected,
        Domain.Common.ValueObjects.Price actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }

    public static void AssertPriceException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);

        var entityValidationException = (EntityValidationException)exception;

        Assert.NotEmpty(entityValidationException.Errors);
    }
}
