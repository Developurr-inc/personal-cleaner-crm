namespace Orderly.Domain.UnitTests.TestUtils.Price;

public sealed class PriceFixture : BaseFixture
{
    public static Domain.Common.ValueObjects.Price CreatePrice()
    {
        var price = decimal.Parse(Faker.Commerce.Price());

        return Domain.Common.ValueObjects.Price.Create(price);
    }


    public static decimal CreateInvalidPrice()
    {
        return decimal.Parse(Faker.Commerce.Price()) * -1M;
    }
}