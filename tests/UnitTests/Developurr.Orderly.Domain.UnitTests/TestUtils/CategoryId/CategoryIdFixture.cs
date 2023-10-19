namespace Developurr.Orderly.Domain.UnitTests.TestUtils.CategoryId;

public static class CategoryIdFixture
{
    public static Developurr.Orderly.Domain.Category.ValueObjects.CategoryId GenerateId()
    {
        return Developurr.Orderly.Domain.Category.ValueObjects.CategoryId.Generate();
    }
}
