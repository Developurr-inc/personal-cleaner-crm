using Orderly.Domain.SeedWork;
namespace Orderly.Domain.Customer.ValueObjects;
public sealed class CustomerId : ValueObject
{
    public Guid Value { get; }
    private CustomerId()
    {
        Value = Guid.NewGuid();
    }
    public static CustomerId Create()
    {
        return new CustomerId();
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
