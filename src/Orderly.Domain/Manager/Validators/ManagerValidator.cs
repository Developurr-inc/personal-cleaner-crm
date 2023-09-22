using Orderly.Domain.Validation;

namespace Orderly.Domain.Manager.Validators;

public sealed class ManagerValidator : Validator
{
    private readonly string _name;

    public ManagerValidator(string name)
    {
        _name = name;
    }

    public override void Validate()
    {
        ValidateManagerName("Name");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateManagerName(string fieldName)
    {
        ValidationRules.ValidateRequired(_name, fieldName, this);
        ValidationRules.ValidateStringLength(
            _name,
            fieldName,
            ManagerValidatorConfig.NameMinLength,
            ManagerValidatorConfig.NameMaxLength,
            this
        );
    }
}
