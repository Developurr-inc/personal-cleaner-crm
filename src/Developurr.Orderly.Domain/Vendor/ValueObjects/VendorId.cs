using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Vendor.ValueObjects;

public sealed class VendorId : Identifier<Guid>
{
    private VendorId(Guid value)
        : base(value) { }

    public static VendorId Generate()
    {
        return new VendorId(Guid.NewGuid());
    }
}
