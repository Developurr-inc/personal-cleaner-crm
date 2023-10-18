namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Quantity;

public sealed class QuantityFixture
{
    public static Shared.ValueObjects.Quantity CreateQuantity()
    {
        return Shared.ValueObjects.Quantity.Create(
            Constants.Constants.Quantity.Value    
        );
    }
}