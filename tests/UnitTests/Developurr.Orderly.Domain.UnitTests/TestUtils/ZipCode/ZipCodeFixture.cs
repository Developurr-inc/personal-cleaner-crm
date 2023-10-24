namespace Developurr.Orderly.Domain.UnitTests.TestUtils.ZipCode;

public static class ZipCodeFixture
{
    public static Developurr.Orderly.Domain.Shared.ValueObjects.ZipCode CreateZipCode()
    {
        return Developurr.Orderly.Domain.Shared.ValueObjects.ZipCode.Create("25680-510");
    }

    public static string CreateInvalidZipCode()
    {
        return "123-20";
    }
}