namespace Orderly.Domain.UnitTests.TestUtils.Cpf;

public static class CpfFixture
{
    public static Domain.Common.ValueObjects.Cpf CreateCpf()
    {
        return Domain.Common.ValueObjects.Cpf.Create(
            Constants.Constants.Cpf.CpfValue    
        );
    }
}
