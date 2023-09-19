namespace Orderly.Domain.UnitTests.TestUtils.Cpf;

public sealed class CpfAssertion : BaseAssertion
{
    public static void AssertCpf(
        Domain.Common.ValueObjects.Cpf expected,
        Domain.Common.ValueObjects.Cpf actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
}
