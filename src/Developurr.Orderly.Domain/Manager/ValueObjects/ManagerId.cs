using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Manager.ValueObjects;

public sealed class ManagerId : Identifier<Guid>
{
    private ManagerId(Guid value)
        : base(value) { }

    public static ManagerId Generate()
    {
        return new ManagerId(Guid.NewGuid());
    }
}
