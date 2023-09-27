namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Cnpj
    {
        public const string CnpjValue = "42591651000143";
    }

    public static class InvalidCnpj
    {
        public const string ShortCnpj = "4259165100014";
        public const string LongCnpj = "425916510001431";
        public const string InvalidCnpjLastDigit = "42591651000144";
        public const string NonNumeriCnpj = "testingtesting";
    }
}