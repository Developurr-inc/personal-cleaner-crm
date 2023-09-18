using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Email;

public sealed class EmailAssertion : BaseAssertion
{
    public static void AssertEmail(
        Domain.Common.ValueObjects.Email expected,
        Domain.Common.ValueObjects.Email actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
}
