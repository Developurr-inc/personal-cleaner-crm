using Orderly.Domain.Order.Validators;

namespace Orderly.Domain.UnitTests.TestUtils.Discount;

public sealed class DiscountFixture
{
    public static Domain.Order.ValueObjects.Discount CreateDiscount()
    {
        return Domain.Order.ValueObjects.Discount.Create(
            Constants.Constants.Discount.DiscountValue    
        );
    }
}