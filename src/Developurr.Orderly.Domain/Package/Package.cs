using Developurr.Orderly.Domain.Package.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.Package;

public sealed class Package : Entity<PackageId>, IAggregateRoot
{
    public NonEmptyText Name { get; }

    private Package(PackageId packageId, NonEmptyText name) : base(packageId)
    {
        Name = name;
    }

    public static Package Create(string name)
    {
        var packageId = PackageId.Generate();
        var nameObj = NonEmptyText.Create(name);
        
        return new Package(packageId, nameObj);
    }
}
