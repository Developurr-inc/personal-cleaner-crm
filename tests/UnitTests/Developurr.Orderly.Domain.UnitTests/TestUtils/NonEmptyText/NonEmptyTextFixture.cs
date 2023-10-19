namespace Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;

public static class NonEmptyTextFixture
{
    public static Shared.ValueObjects.NonEmptyText CreateNonEmptyText()
    {
        return Shared.ValueObjects.NonEmptyText.Create("Name");
    }
}
