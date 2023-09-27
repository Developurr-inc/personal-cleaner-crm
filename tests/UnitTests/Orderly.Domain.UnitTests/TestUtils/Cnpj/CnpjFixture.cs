namespace Orderly.Domain.UnitTests.TestUtils.Cnpj;

public static class CnpjFixture
{
    public static Domain.Common.ValueObjects.Cnpj CreateCnpj()
    {
        return Domain.Common.ValueObjects.Cnpj.Create(
            Constants.Constants.Cnpj.CnpjValue    
        );
    }
}
