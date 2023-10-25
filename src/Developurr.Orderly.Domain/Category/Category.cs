using Developurr.Orderly.Domain.Category.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.Category;

public sealed partial class Category : Entity<CategoryId>, IAggregateRoot
{
    public NonEmptyText Name { get; }
    public OptionalText Description { get; }
    public ActiveStatus Active { get; private set; }
    private Category(
        CategoryId categoryId,
        NonEmptyText name, 
        OptionalText description,
        ActiveStatus active)
        : base(categoryId)
    {
        Name = name;
        Description = description;
        Active = active;
    }

    public void Deactivate()
    {
        if (Active.IsActive)
            Active = ActiveStatus.Inactive;
    }
    public static Category Create(string name, string description)
    {
        var categoryId = CategoryId.Generate();
        var nameObj = NonEmptyText.Create(name);
        var descriptionObj = OptionalText.Create(description);
        var activeObj = ActiveStatus.Active;

        return new Category(
            categoryId,
            nameObj,
            descriptionObj,
            activeObj
            );
    }
}
