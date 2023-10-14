using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.SalesConsultant.ValueObjects;

public sealed class SalesConsultantId : Identifier<Guid>
{
    private SalesConsultantId(Guid value)
        : base(value) { }

    public static SalesConsultantId Generate()
    {
        return new SalesConsultantId(Guid.NewGuid());
    }
}
