using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Product.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Value { get; }

    private ProductId()
    {
        Value = Guid.NewGuid();
    }

    public static ProductId Generate()
    {
        return new ProductId();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }    
}


