namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Cnpj;

public static class CnpjFixture
{
    public static Developurr.Orderly.Domain.Shared.ValueObjects.Cnpj CreateCnpj()
    {
        return Developurr.Orderly.Domain.Shared.ValueObjects.Cnpj.Create(
            Constants.Constants.Cnpj.CnpjValue    
        );
    }
}
