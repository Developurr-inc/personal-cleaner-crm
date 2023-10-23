namespace Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;

public static class NonEmptyTextFixture
{
    public static Domain.Shared.ValueObjects.NonEmptyText CreateNonEmptyText(string value)
    {
        return Domain.Shared.ValueObjects.NonEmptyText.Create(value);
    }

    public static Domain.Shared.ValueObjects.NonEmptyText CreateNonEmptyText(int length = 10)
    {
        return CreateNonEmptyText(new string('a', length));
    }

    public static string CreateInvalidNonEmptyText()
    {
        return "  ";
    }

    public static string CreateInvalidLongNonEmptyText()
    {
        return new string('a', 1_001);
    }
}
