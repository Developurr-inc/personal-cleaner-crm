namespace Orderly.Domain.UnitTests.TestUtils.Cpf;

public sealed class CpfGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateCpfs()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { CpfFixture.CreateCpf() };
    }

    public static IEnumerable<object[]> CreateInvalidCpfs()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[] { CpfFixture.CreateInvalidCpf() };
            yield return new object[] { CpfFixture.CreateWrongSizeCpf() };
        }
    }
}
