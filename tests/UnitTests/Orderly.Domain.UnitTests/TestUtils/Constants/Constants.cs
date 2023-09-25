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

    public static class Cpf
    {
        public const string CpfValue = "546.471.429-49";
    }
    
    public static class InvalidCpf
    {
        public const string ShortCpf = "546.471.429-4";
        public const string LongCpf = "546.471.429-491";
        public const string InvalidCpfLastDigit = " 546.471.429-41";
    }
}