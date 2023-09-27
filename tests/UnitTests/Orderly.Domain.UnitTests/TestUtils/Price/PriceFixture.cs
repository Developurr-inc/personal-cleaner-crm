namespace Orderly.Domain.UnitTests.TestUtils.Price;

public static class PriceFixture
{
    public static Domain.Common.ValueObjects.Price CreatePrice()
    {
        return Domain.Common.ValueObjects.Price.Create(
            Constants.Constants.Price.PriceValue
        );
    }
}