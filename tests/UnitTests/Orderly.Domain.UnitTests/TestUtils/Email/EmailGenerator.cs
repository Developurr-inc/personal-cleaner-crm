namespace Orderly.Domain.UnitTests.TestUtils.Email;

public sealed class EmailGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateEmails()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                EmailFixture.CreateEmail()
            };
    }


    public static IEnumerable<object[]> CreateInvalidEmailAddresses()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                EmailFixture.CreateInvalidAtEmailAddress()
            };
            
            yield return new object[]
            {
                EmailFixture.CreateInvalidDotEmailAddress()
            };
            
            yield return new object[]
            {
                EmailFixture.CreateInvalidAtAndDotEmailAddress()
            };

            yield return new object[]
            {
                EmailFixture.CreateShortEmailAddress()
            };

            yield return new object[]
            {
                EmailFixture.CreateLongEmailAddress()
            };
        }
    }
}