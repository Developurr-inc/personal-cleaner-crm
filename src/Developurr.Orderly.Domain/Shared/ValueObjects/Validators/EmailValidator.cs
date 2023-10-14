using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

public sealed class EmailValidator : Validator
{
    private readonly string _email;

    public EmailValidator(string email)
    {
        _email = email;
    }

    public override void Validate()
    {
        ValidateEmail("Email Address");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateEmail(string fieldName)
    {
        ValidationRules.ValidateRequired(_email, fieldName, this);
        ValidationRules.ValidateStringLength(
            _email,
            fieldName,
            EmailValidatorConfig.EmailMinLength,
            EmailValidatorConfig.EmailMaxLength,
            this
        );
        ValidationRules.ValidateEmail(_email, fieldName, this);
    }
}
