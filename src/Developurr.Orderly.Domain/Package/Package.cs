using Developurr.Orderly.Domain.Package.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.Package;

public sealed partial class Package : Entity<PackageId>, IAggregateRoot
{
    public NonEmptyText Name { get; }
    public ActiveStatus Active { get; private set; }

    private Package(
        PackageId packageId,
        NonEmptyText name,
        ActiveStatus active
        )
        : base(packageId)
    {
        Name = name;
        Active = active;
    }
    
    public void Deactivate()
    {
        if (Active.IsActive)
            Active = ActiveStatus.Inactive;
    }
    public static Package Create(string name)
    {
        var packageId = PackageId.Generate();
        var nameObj = NonEmptyText.Create(name);
        var activeObj = ActiveStatus.Active;
        return new Package(packageId, nameObj, activeObj);
    }
}
