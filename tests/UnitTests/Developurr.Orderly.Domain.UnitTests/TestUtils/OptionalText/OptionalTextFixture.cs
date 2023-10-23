namespace Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;

public static class OptionalTextFixture
{
    public static Domain.Shared.ValueObjects.OptionalText CreateOptionalText(string value)
    {
        return Domain.Shared.ValueObjects.OptionalText.Create(value);
    }

    public static Domain.Shared.ValueObjects.OptionalText CreateOptionalText(int length = 30)
    {
        return CreateOptionalText(new string('a', length));
    }

    public static string CreateInvalidOptionalText()
    {
        return new string('a', 10_001);
    }
}
