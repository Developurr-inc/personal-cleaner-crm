namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Cpf;

public static class CpfFixture
{
    public static Developurr.Orderly.Domain.Shared.ValueObjects.Cpf CreateCpf()
    {
        return Developurr.Orderly.Domain.Shared.ValueObjects.Cpf.Create(
            Constants.Constants.Cpf.CpfValue    
        );
    }
}
