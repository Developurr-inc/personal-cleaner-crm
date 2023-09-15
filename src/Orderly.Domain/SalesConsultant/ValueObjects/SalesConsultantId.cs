using Orderly.Domain.SeedWork;

namespace Orderly.Domain.SalesConsultant.ValueObjects;

public sealed class SalesConsultantId : ValueObject
{
    public Guid Value { get; }

    private SalesConsultantId()
    {
        Value = Guid.NewGuid();
    }

    public static SalesConsultantId Create()
    {
        return new SalesConsultantId();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
