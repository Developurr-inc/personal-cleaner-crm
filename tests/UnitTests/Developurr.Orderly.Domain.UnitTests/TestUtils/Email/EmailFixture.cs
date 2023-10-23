namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Email;

public static class EmailFixture
{
    public static Developurr.Orderly.Domain.Shared.ValueObjects.Email CreateEmail()
    {
        return Developurr.Orderly.Domain.Shared.ValueObjects.Email.Create("abc@def.ghi");
    }

    public static string CreateInvalidEmail()
    {
        return "a@a.";
    }
}
