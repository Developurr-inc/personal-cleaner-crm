using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Customer.ValueObjects;

public sealed class CustomerId : Identifier<Guid>
{
    private CustomerId()
        : base(Guid.Empty){ }
    private CustomerId(Guid value)
        : base(value) { }

    public static CustomerId Generate()
    {
        return new CustomerId(Guid.NewGuid());
    }
}
