using Developurr.Orderly.Domain.Category.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.Category;

public sealed class Category : Entity<CategoryId>, IAggregateRoot
{
    public NonEmptyText Name { get; }
    public OptionalText Description { get; }

    private Category(CategoryId categoryId, NonEmptyText name, OptionalText description) : base(categoryId)
    {
        Name = name;
        Description = description;
    }

    public static Category Create(string name, string description)
    {
        var categoryId = CategoryId.Generate();
        var nameObj = NonEmptyText.Create(name);
        var descriptionObj = OptionalText.Create(description);

        return new Category(categoryId, nameObj, descriptionObj);
    }
}
