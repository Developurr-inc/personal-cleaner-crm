using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Manager.ValueObjects;

public class ManagerId : ValueObject
{   
    public Guid Value { get; }
    
    
    private ManagerId()
    {
        Value = Guid.NewGuid();
    }
    
    
    public static ManagerId Create()
    {
        return new ManagerId();
    }
    
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}