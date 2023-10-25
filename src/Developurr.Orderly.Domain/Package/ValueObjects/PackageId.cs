using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Package.ValueObjects;

public sealed class PackageId : Identifier<Guid>
{
    private PackageId()
        : base(Guid.Empty){ }
    
    private PackageId(Guid value)
        : base(value) { }

    public static PackageId Generate()
    {
        return new PackageId(Guid.NewGuid());
    }
}
