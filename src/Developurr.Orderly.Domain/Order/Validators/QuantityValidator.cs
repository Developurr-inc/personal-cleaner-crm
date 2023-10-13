using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Order.Validators;

public sealed class QuantityValidator : Validator
{
    private readonly int _value;

    public QuantityValidator(int value)
    {
        _value = value;
    }

    public override void Validate()
    {
        ValidateQuantity("Quantity");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateQuantity(string fieldName)
    {
        ValidationRules.ValidateRange(
            _value,
            fieldName,
            QuantityValidatorConfig.QuantityMin,
            QuantityValidatorConfig.QuantityMax,
            this
        );
    }
}
