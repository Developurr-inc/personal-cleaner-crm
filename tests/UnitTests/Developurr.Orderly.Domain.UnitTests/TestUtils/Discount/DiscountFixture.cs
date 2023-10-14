namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Discount;

public sealed class DiscountFixture
{
    public static Developurr.Orderly.Domain.Order.ValueObjects.Discount CreateDiscount()
    {
        return Developurr.Orderly.Domain.Order.ValueObjects.Discount.Create(
            Constants.Constants.Discount.DiscountValue    
        );
    }
}