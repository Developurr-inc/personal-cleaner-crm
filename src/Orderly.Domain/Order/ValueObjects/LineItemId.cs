using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order.ValueObjects;

public sealed class LineItemId : ValueObject
{
    public Guid Value { get; }

    private LineItemId(Guid lineItemId)
    {
        Value = lineItemId;
    }

    public static LineItemId Generate()
    {
        var lineItemId = Guid.NewGuid();

        return new LineItemId(lineItemId);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
