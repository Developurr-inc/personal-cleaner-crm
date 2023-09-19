using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Discount;

public sealed class DiscountAssertion
{
    public static void AssertDiscount(
        Domain.Order.ValueObjects.Discount expected,
        Domain.Order.ValueObjects.Discount actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
    
    public static void AssertDiscountException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);

        var entityValidationException = (EntityValidationException)exception;

        Assert.NotEmpty(entityValidationException.Errors);
    }
}