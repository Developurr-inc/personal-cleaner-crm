using Orderly.Domain.Validation;

namespace Orderly.Domain.Common.ValueObjects.Validators;

public sealed class EmailValidator : Validator
{
    private readonly string _email;

    public const int EmailMinLength = 5;
    public const int EmailMaxLength = 255;

    public EmailValidator(string email)
    {
        _email = email;
    }

    public override void Validate()
    {
        ValidateEmail();

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateEmail()
    {
        const string fieldName = "Email Address";

        ValidationRules.ValidateRequired(_email, fieldName, this);
        ValidationRules.ValidateStringLength(
            _email,
            fieldName,
            EmailMinLength,
            EmailMaxLength,
            this
        );
        ValidationRules.ValidateEmail(_email, fieldName, this);
    }
}
