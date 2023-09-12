using Orderly.Domain.SeedWork;
using Orderly.Domain.Common.ValueObjects.Validators;

namespace Orderly.Domain.Common.ValueObjects;

public sealed class Email : ValueObject
{
    public string Value { get; }


    private Email(string email)
    {
        Value = email;
    }


    public static Email Create(string email)
    {
        var emailTrimmed = email.Trim();

        var emailValidator = new EmailValidator(emailTrimmed);
        emailValidator.Validate();

        return new Email(emailTrimmed);
    }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}