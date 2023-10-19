namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Price;

public static class PriceFixture
{
    public static Shared.ValueObjects.Price CreatePrice()
    {
        return Shared.ValueObjects.Price.Create(123m);
    }
}
