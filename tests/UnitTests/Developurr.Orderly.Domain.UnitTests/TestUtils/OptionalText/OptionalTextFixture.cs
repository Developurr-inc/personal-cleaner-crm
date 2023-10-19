namespace Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;

public static class OptionalTextFixture
{
    public static Shared.ValueObjects.OptionalText CreateOptionalText()
    {
        return Shared.ValueObjects.OptionalText.Create("Description");
    }
}
