using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;

namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Category;

public static class CategoryFixture
{
    public static Domain.Category.Category CreateCategory()
    {
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();

        return Domain.Category.Category.Create(name.Value, description.Value);
    }
}
