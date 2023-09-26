namespace Orderly.Domain.UnitTests.TestUtils.Email;

public static class EmailFixture
{
    public static Domain.Common.ValueObjects.Email CreateEmail()
    {
        return Domain.Common.ValueObjects.Email.Create(
            Constants.Constants.Email.EmailValue
        );
    }
}