namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Phone;

public static class PhoneFixture
{
    public static Domain.Shared.ValueObjects.Phone CreatePhone()
    {
        return Domain.Shared.ValueObjects.Phone.Create("21998345677");
    }

    public static string CreateInvalidPhone()
    {
        return "24950";
    }
}
