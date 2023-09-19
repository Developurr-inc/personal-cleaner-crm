namespace Orderly.Domain.UnitTests.TestUtils.Phone;

public sealed class PhoneAssertion : BaseAssertion
{
    public static void AssertPhone(
        Domain.Common.ValueObjects.Phone expected,
        Domain.Common.ValueObjects.Phone actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
}
