using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Quantity;

public class QuantityAssertion
{
    public static void AssertQuantity(
        Domain.Quantity.ValueObjects.Quantity expected,
        Domain.Quantity.ValueObjects.Quantity actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
    
    public static void AssertQuantityException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);

        var entityValidationException = (EntityValidationException)exception;

        Assert.NotEmpty(entityValidationException.Errors);
    }
}