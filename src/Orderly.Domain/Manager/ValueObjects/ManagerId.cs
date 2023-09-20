using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Manager.ValueObjects;

public sealed class ManagerId : ValueObject
{
    public Guid Value { get; }

    private ManagerId(Guid value)
    {
        Value = value;
    }

    public static ManagerId Generate()
    {
        var guid = Guid.NewGuid();
        return new ManagerId(guid);
    }
    
    public static ManagerId Restore(string value)
    {
        var guid = Guid.Parse(value);
        return new ManagerId(guid);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
