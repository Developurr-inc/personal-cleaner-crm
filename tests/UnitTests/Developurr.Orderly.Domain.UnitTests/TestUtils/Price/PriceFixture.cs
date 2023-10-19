namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Price;

public static class PriceFixture
{
    public static Developurr.Orderly.Domain.Shared.ValueObjects.Price CreatePrice()
    {
        return Developurr.Orderly.Domain.Shared.ValueObjects.Price.Create(
           10.99m
        );
    }
}