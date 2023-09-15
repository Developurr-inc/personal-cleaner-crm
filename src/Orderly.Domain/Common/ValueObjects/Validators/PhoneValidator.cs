using Orderly.Domain.Validation;

namespace Orderly.Domain.Common.ValueObjects.Validators;

public sealed class PhoneValidator : Validator
{
    private readonly string _phone;

    public const int PhoneMinLength = 8;
    public const int PhoneMaxLength = 18;

    public PhoneValidator(string phone)
    {
        _phone = phone;
    }

    public override void Validate()
    {
        ValidatePhone();

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidatePhone()
    {
        const string fieldName = "Phone Number";

        ValidationRules.ValidateRequired(_phone, fieldName, this);
        ValidationRules.ValidateStringLength(
            _phone,
            fieldName,
            PhoneMinLength,
            PhoneMaxLength,
            this
        );
        ValidationRules.ValidatePhoneNumber(_phone, fieldName, this);
    }
}
