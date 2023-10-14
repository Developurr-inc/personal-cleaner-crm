using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Order.Validators;

public sealed class DiscountValidator : Validator
{
    private readonly decimal _value;

    public DiscountValidator(decimal value)
    {
        _value = value;
    }

    public override void Validate()
    {
        ValidateDiscount("Discount");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateDiscount(string fieldName)
    {
        ValidationRules.ValidateRange(
            _value,
            fieldName,
            DiscountValidatorConfig.DiscountMin,
            DiscountValidatorConfig.DiscountMax,
            this
        );
    }
}
