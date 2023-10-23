namespace Developurr.Orderly.Domain.UnitTests.TestUtils.CategoryId;

public static class CategoryIdFixture
{
    public static Domain.Category.ValueObjects.CategoryId GenerateId()
    {
        return Domain.Category.ValueObjects.CategoryId.Generate();
    }
}
