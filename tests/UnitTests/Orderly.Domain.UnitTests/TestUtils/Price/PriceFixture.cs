namespace Orderly.Domain.UnitTests.TestUtils.Price;

public sealed class PriceFixture : BaseFixture
{
    private static Domain.Common.ValueObjects.Price CreateValidPrice()
    {
        var price = decimal.Parse(Faker.Commerce.Price());

        return Domain.Common.ValueObjects.Price.Create(price);
    }


    public static Domain.Common.ValueObjects.Price CreatePrice(
        Domain.Common.ValueObjects.Price? price = null,
        decimal? value = null
    )
    {
        var lPrice = price ?? CreateValidPrice();

        return Domain.Common.ValueObjects.Price.Create(value ?? lPrice.Value);
    }


    public static decimal CreateInvalidPrice()
    {
        return decimal.Parse(Faker.Commerce.Price()) * -1M;
    }
}