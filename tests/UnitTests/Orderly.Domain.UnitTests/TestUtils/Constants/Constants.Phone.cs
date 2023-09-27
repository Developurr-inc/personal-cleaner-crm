namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Phone
    {
        public const string PhoneValue = "21998345677";
    }
    
    public static class InvalidPhone
    {
        public const string ShortPhone = "9983456";
        public const string LongPhone = "9983456771234567890";
        public const string NonNumericPhone = "testingta";
    }
}