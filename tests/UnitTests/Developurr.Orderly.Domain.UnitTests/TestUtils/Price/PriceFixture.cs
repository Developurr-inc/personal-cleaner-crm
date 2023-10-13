namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Price;

public static class PriceFixture
{
    public static Developurr.Orderly.Domain.Shared.ValueObjects.Price CreatePrice()
    {
        return Developurr.Orderly.Domain.Shared.ValueObjects.Price.Create(
            Constants.Constants.Price.PriceValue
        );
    }
}