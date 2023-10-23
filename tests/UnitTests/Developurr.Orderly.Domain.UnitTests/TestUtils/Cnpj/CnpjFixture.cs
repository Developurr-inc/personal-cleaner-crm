namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Cnpj;

public static class CnpjFixture
{
    public static Developurr.Orderly.Domain.Shared.ValueObjects.Cnpj CreateCnpj()
    {
        return Developurr.Orderly.Domain.Shared.ValueObjects.Cnpj.Create("42591651000143");
    }

    public static string CreateInvalidCnpj()
    {
        return "42591651000144";
    }
}
