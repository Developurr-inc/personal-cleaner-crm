using Orderly.Domain.Common.ValueObjects.Validators;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Email;

public sealed class EmailFixture : BaseFixture
{
    private static Domain.Common.ValueObjects.Email CreateValidEmail()
    {
        var email = Faker.Internet.Email();

        return Domain.Common.ValueObjects.Email.Create(email);
    }


    public static Domain.Common.ValueObjects.Email CreateEmail(
        Domain.Common.ValueObjects.Email? email = null,
        string? value = null
    )
    {
        var lEmail = email ?? CreateValidEmail();

        return Domain.Common.ValueObjects.Email.Create(value ?? lEmail.Value);
    }


    public static string CreateInvalidAtEmailAddress()
    {
        var email = Faker.Internet.Email();

        return email.Replace('@', 'a');
    }


    public static string CreateInvalidDotEmailAddress()
    {
        var email = Faker.Internet.Email();

        return email.Replace('.', 'a');
    }


    public static string CreateInvalidAtAndDotEmailAddress()
    {
        var email = Faker.Internet.Email();

        email = email.Replace('@', 'a');
        email = email.Replace('.', 'a');

        return email;
    }


    public static string CreateShortEmailAddress()
    {
        return StringFixture.CreateString(
            1,
            EmailValidator.EmailMinLength - 1
        );
    }


    public static string CreateLongEmailAddress()
    {
        return StringFixture.CreateString(
            EmailValidator.EmailMaxLength + 1,
            1_000
        );
    }
}