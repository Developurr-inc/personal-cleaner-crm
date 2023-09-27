namespace Orderly.Domain.UnitTests.TestUtils.Cnpj;

public sealed class CnpjAssertion : BaseAssertion
{
    public static void AssertCnpj(
        Domain.Common.ValueObjects.Cnpj expected,
        Domain.Common.ValueObjects.Cnpj actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }
}
