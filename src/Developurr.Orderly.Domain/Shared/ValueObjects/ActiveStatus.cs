using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class ActiveStatus : ValueObject
{
    public bool IsActive { get; }

    private ActiveStatus(){ }
    
    private ActiveStatus(bool isActive)
    {
        IsActive = isActive;
    }

    public static ActiveStatus Active => new(true);

    public static ActiveStatus Inactive => new(false);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsActive;
    }
}
