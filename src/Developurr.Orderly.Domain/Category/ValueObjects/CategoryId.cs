using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Category.ValueObjects;

public sealed class CategoryId : Identifier<Guid>
{
    private CategoryId(Guid value)
        : base(value) { }

    public static CategoryId Generate()
    {
        return new CategoryId(Guid.NewGuid());
    }
}
