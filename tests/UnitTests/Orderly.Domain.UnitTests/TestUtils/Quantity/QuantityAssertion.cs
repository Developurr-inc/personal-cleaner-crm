using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Quantity;

public sealed class QuantityAssertion : BaseAssertion
{
    public static void AssertQuantity(
        Domain.Quantity.ValueObjects.Quantity expected,
        Domain.Quantity.ValueObjects.Quantity actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
}
