using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Order.ValueObjects;

public sealed class LineItemId : Identifier<Guid>
{
    private LineItemId()
        : base(Guid.Empty){ }

    private LineItemId(Guid value)
        : base(value) { }

    public static LineItemId Generate()
    {
        return new LineItemId(Guid.NewGuid());
    }
}
