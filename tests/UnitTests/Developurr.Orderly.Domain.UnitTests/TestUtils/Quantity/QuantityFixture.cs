namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Quantity;

public sealed class QuantityFixture
{
    public static Domain.Shared.ValueObjects.Quantity CreateQuantity()
    {
        return Domain.Shared.ValueObjects.Quantity.Create(20);
    }
}