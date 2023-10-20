namespace Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;

public static class NonEmptyTextFixture
{
    public static Domain.Shared.ValueObjects.NonEmptyText CreateNonEmptyText()
    {
        return Domain.Shared.ValueObjects.NonEmptyText.Create("Name");
    }
}
