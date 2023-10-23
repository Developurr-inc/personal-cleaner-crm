using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

public sealed class ZipCodeValidator : Validator
{
    private readonly string _zipCode;

    public ZipCodeValidator(string zipCode)
    {
        _zipCode = zipCode;
    }

    public override void Validate()
    {
        ValidateZipCode("ZipCode Address");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateZipCode(string fieldName)
    {
        ValidationRules.ValidateRequired(_zipCode, fieldName, this);
        ValidationRules.ValidateStringLength(
            _zipCode,
            fieldName,
            ZipCodeValidatorConfig.ZipCodeMinLength,
            ZipCodeValidatorConfig.ZipCodeMaxLength,
            this
        );
        ValidationRules.ValidateZipCode(_zipCode, fieldName, this);
    }
}