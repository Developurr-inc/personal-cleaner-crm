using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order.ValueObjects;

public sealed class OrderId : Identifier<Guid>
{
    private OrderId(Guid value)
        : base(value) { }

    public static OrderId Generate()
    {
        return new OrderId(Guid.NewGuid());
    }
}
