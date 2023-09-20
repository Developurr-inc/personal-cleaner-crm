using Orderly.Domain.SeedWork;

namespace Orderly.Domain.SalesConsultant.ValueObjects;

public sealed class SalesConsultantId : ValueObject
{
    public Guid Value { get; }

    private SalesConsultantId(Guid value)
    {
        Value = value;
    }

    public static SalesConsultantId Generate()
    {
        var guid = Guid.NewGuid();
        return new SalesConsultantId(guid);
    }

    public static SalesConsultantId Restore(string value)
    {
        var guid = Guid.Parse(value);
        return new SalesConsultantId(guid);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
