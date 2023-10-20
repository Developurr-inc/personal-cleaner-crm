namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Price;

public static class PriceFixture
{
    public static Domain.Shared.ValueObjects.Price CreatePrice()
    {
        return Domain.Shared.ValueObjects.Price.Create(123m);
    }
}
