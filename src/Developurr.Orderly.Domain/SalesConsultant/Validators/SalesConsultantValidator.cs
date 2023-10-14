using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.SalesConsultant.Validators;

public sealed class SalesConsultantValidator : Validator
{
    private readonly string _name;

    public SalesConsultantValidator(string name)
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
            SalesConsultantValidatorConfig.NameMinLength,
            SalesConsultantValidatorConfig.NameMaxLength,
            this
        );
    }
}
