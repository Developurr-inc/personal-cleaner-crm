using Orderly.Domain.Order.Validators;

namespace Orderly.Domain.UnitTests.TestUtils.Quantity;

public sealed class QuantityFixture
{
    public static Domain.Order.ValueObjects.Quantity CreateQuantity()
    {
        return Domain.Order.ValueObjects.Quantity.Create(
            Constants.Constants.Quantity.Value    
        );
    }
}