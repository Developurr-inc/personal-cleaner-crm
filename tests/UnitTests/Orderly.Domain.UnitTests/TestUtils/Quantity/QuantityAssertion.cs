using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Quantity;

public sealed class QuantityAssertion : BaseAssertion
{
    public static void AssertQuantity(
        Domain.Order.ValueObjects.Quantity expected,
        Domain.Order.ValueObjects.Quantity actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
}
