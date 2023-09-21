using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Customer.ValueObjects;

public sealed class CustomerId : ValueObject
{
    public Guid Value { get; }

    private CustomerId(Guid value)
    {
        Value = value;
    }
    
    public static CustomerId Generate()
    {
        var guid = Guid.NewGuid();
        return new CustomerId(guid);
    }
    
    public static CustomerId Restore(string value)
    {
        var guid = Guid.Parse(value);
        return new CustomerId(guid);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
