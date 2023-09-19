using Orderly.Domain.Validation;

namespace Orderly.Domain.Quantity.Validators;

public class QuantityValidator : Validator
{
    private readonly int _value;
    
    public const int QuantityMin = 0;
    public const int QuantityMax = int.MaxValue;
    
    public QuantityValidator(int value)
    {
        _value = value;
    }
    
    public override void Validate()
    {
        ValidateQuantity();

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }
    
    private void ValidateQuantity()
    {
        const string fieldName = "Quantity";

        ValidationRules.ValidateRange(_value, fieldName, QuantityMin, QuantityMax, this);
    }
}