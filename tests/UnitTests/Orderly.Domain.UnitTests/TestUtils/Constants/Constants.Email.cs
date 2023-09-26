namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Email
    {
        public const string EmailValue = "email@email.com";
    }

    public static class InvalidEmail
    {
        public const string InvalidAtEmailAddress = "emailaemail.com";
        public const string InvalidDotEmailAddress = "email@emailacom";
        public const string InvalidAtAndDotEmailAddress = "emailaemailacom";
        public const string ShortEmailAddress = "a@a.";
        public const string LongEmailAddress = "emailmuitolongoemailmuitolongoemailmuitolongoemailmuitolongoemailmuitolongoemailmuitolongoemailmuitolongoemailmuitolongoemailmuitolongoemailmuitolongoemailmuitolongo@dominiomuitolongoparasimularumexemploparasimularumexemploparasimularumexemploparasimularumexemplo.com";
    }
}