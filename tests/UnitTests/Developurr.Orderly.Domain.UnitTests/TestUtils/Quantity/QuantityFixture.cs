namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Quantity;

public sealed class QuantityFixture
{
    public static Developurr.Orderly.Domain.Order.ValueObjects.Quantity CreateQuantity()
    {
        return Developurr.Orderly.Domain.Order.ValueObjects.Quantity.Create(
            Constants.Constants.Quantity.Value    
        );
    }
}