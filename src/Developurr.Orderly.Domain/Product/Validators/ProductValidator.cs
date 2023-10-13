using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Product.Validators;

public sealed class ProductValidator : Validator
{
    private readonly string _name;

    public ProductValidator(string name)
    {
        _name = name;
    }

    public override void Validate()
    {
        ValidateProductName("Name");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateProductName(string fieldName)
    {
        ValidationRules.ValidateRequired(_name, fieldName, this);
        ValidationRules.ValidateStringLength(
            _name,
            fieldName,
            ProductValidatorConfig.NameMinLength,
            ProductValidatorConfig.NameMaxLength,
            this
        );
    }
}
