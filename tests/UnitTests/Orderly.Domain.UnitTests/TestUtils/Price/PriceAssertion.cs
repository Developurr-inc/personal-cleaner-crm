using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Price;

public sealed class PriceAssertion : BaseAssertion
{
    public static void AssertPrice(
        Domain.Common.ValueObjects.Price expected,
        Domain.Common.ValueObjects.Price actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
}
