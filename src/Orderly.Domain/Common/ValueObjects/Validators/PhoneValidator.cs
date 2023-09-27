using Orderly.Domain.Validation;

namespace Orderly.Domain.Common.ValueObjects.Validators;

public sealed class PhoneValidator : Validator
{
    private readonly string _phone;

    public PhoneValidator(string phone)
    {
        _phone = phone;
    }

    public override void Validate()
    {
        ValidatePhone("Phone Number");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidatePhone(string fieldName)
    {
        ValidationRules.ValidateRequired(_phone, fieldName, this);
        ValidationRules.ValidateStringLength(
            _phone,
            fieldName,
            PhoneValidatorConfig.PhoneMinLength,
            PhoneValidatorConfig.PhoneMaxLength,
            this
        );
        ValidationRules.ValidatePhoneNumber(_phone, fieldName, this);
    }
}
