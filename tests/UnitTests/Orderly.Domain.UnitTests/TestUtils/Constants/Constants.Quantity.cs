namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Quantity
    {
        public const int Value = 20;
    }

    public static class InvalidQuantity
    {
        public const int NegativeQuantity = -1;
        public const int OverUpperLimitQuantity = int.MaxValue;
    }
}