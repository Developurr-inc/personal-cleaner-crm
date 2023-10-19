using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Vendor.Validators;

public sealed class VendorValidator : Validator
{
    private readonly string _name;

    public VendorValidator(string name)
    {
        _name = name;
    }

    public override void Validate()
    {
        ValidateSalesConsultantName("Name");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateSalesConsultantName(string fieldName)
    {
        ValidationRules.ValidateRequired(_name, fieldName, this);
        ValidationRules.ValidateStringLength(
            _name,
            fieldName,
            VendorValidatorConfig.NameMinLength,
            VendorValidatorConfig.NameMaxLength,
            this
        );
    }
}
