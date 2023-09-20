using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Product.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Value { get; }

    private ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId Generate()
    {
        var guid = Guid.NewGuid();
        return new ProductId(guid);
    }

    public static ProductId Restore(string value)
    {
        var guid = Guid.Parse(value);
        return new ProductId(guid);
    }
    
    

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }    
}


