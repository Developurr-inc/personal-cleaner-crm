using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Discount;

public class DiscountAssertion : BaseAssertion
{
    public static void AssertDiscount(
        Domain.Order.ValueObjects.Discount expected,
        Domain.Order.ValueObjects.Discount actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
}