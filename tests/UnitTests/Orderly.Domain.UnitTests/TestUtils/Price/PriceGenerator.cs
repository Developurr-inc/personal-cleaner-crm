namespace Orderly.Domain.UnitTests.TestUtils.Price;

public sealed class PriceGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreatePrices()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                PriceFixture.CreatePrice()
            };
    }


    public static IEnumerable<object[]> CreateInvalidPrices()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                PriceFixture.CreateInvalidPrice()
            };
    }
}