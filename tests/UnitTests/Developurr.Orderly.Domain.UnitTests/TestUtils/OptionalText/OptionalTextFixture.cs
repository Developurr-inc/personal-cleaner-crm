namespace Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;

public static class OptionalTextFixture
{
    public static Domain.Shared.ValueObjects.OptionalText CreateOptionalText()
    {
        return Domain.Shared.ValueObjects.OptionalText.Create("Description");
    }
}
