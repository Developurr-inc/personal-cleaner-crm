namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Cpf;

public static class CpfFixture
{
    public static Domain.Shared.ValueObjects.Cpf CreateCpf()
    {
        return Domain.Shared.ValueObjects.Cpf.Create("54647142949");
    }

    public static string CreateInvalidCpf()
    {
        return "54647142948";
    }
}
