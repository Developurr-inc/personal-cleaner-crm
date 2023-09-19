namespace Orderly.Domain.UnitTests.TestUtils.Discount;

public class DiscountGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateDiscounts()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { DiscountFixture.CreateDiscount() };
    }

    public static IEnumerable<object[]> CreateInvalidDiscounts()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[] { DiscountFixture.CreateBellowMinDiscount() };
            yield return new object[] { DiscountFixture.CreateAboveMaxDiscount() };
        }
    }
}