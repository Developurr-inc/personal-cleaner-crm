namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Discount
    {
        public const decimal DiscountValue = 20;
    }
    
    public static class InvalidDiscount
    {
        public const decimal NegativeDiscount = -1;
        public const decimal OverUpperLimitDiscount = 101;
    }
}