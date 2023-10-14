namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Cpf
    {
        public const string CpfValue = "54647142949";
    }
    
    public static class InvalidCpf
    {
        public const string ShortCpf = "5464714294";
        public const string LongCpf = "546471429491";
        public const string InvalidCpfLastDigit = "54647142941";
        public const string NonNumericCpf = "testingtesting";
    }
}