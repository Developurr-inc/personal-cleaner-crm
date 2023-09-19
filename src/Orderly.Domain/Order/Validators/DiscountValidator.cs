using Orderly.Domain.Validation;

namespace Orderly.Domain.Order.Validators;

public sealed class DiscountValidator : Validator
{
    private readonly decimal _value;
    
    public const int DiscountMin = 0;
    public const int DiscountMax = 100;
    
    public DiscountValidator(decimal value)
    {
        _value = value;
    }
    
    public override void Validate()
    {
        ValidateDiscount();

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }
    
    private void ValidateDiscount()
    {
        const string fieldName = "Discount";

        ValidationRules.ValidateRange(_value, fieldName, DiscountMin, DiscountMax, this);
    }
}