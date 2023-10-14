using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class Email : ValueObject
{
    private readonly string _value;

    private Email(string email)
    {
        _value = email;
    }

    public static Email Create(string email)
    {
        var emailTrimmed = email.Trim();

        var emailValidator = new EmailValidator(emailTrimmed);
        emailValidator.Validate();

        return new Email(emailTrimmed);
    }

    public string Format()
    {
        return _value;
    }

    public override string ToString()
    {
        return Format();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
