using Orderly.Domain.Validation;

namespace Orderly.Domain.SalesConsultant.Validators;

public sealed class SalesConsultantValidator : Validator
{
    private readonly string _name;

    public const int NameMinLength = 5;
    public const int NameMaxLength = 255;

    public SalesConsultantValidator(string name)
    {
        _name = name;
    }

    public override void Validate()
    {
        ValidateSalesConsultantName();

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateSalesConsultantName()
    {
        const string fieldName = "Name";

        ValidationRules.ValidateRequired(_name, fieldName, this);
        ValidationRules.ValidateStringLength(_name, fieldName, NameMinLength, NameMaxLength, this);
    }
}
