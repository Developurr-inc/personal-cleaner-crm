using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Product.ValueObjects;

public sealed class ProductId : Identifier<Guid>
{
    private ProductId(Guid value)
        : base(value) { }

    public static ProductId Generate()
    {
        return new ProductId(Guid.NewGuid());
    }
}
