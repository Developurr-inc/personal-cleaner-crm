namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Cnpj
    {
        public const string CnpjValue = "42.591.651/0001-43";
    }

    public static class InvalidCnpj
    {
        public const string ShortCnpj = "42.591.651/0001-4";
        public const string LongCnpj = "42.591.651/0001-431";
        public const string InvalidCnpjLastDigit = " 42.591.651/0001-44";
    }
}