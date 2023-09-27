using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Customer.ValueObjects;

public sealed class CustomerId : Identifier<Guid>
{
    private CustomerId(Guid value)
        : base(value) { }

    public static CustomerId Generate()
    {
        return new CustomerId(Guid.NewGuid());
    }
}
