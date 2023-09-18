using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order.ValueObjects;

public sealed class OrderId : ValueObject
{
    public Guid Value { get; }

    private OrderId(Guid orderId)
    {
        Value = orderId;
    }

    public static OrderId Generate()
    {
        var orderId = Guid.NewGuid();

        return new OrderId(orderId);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
