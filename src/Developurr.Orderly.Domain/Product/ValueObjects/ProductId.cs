using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Product.ValueObjects;

public sealed class ProductId : Identifier<Guid>
{
    private ProductId()
        : base(Guid.Empty){ }
    
    private ProductId(Guid value)
        : base(value) { }

    public static ProductId Generate()
    {
        return new ProductId(Guid.NewGuid());
    }
}
