using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

public sealed class PriceValidator : Validator
{
    private readonly decimal _price;

    public PriceValidator(decimal price)
    {
        _price = price;
    }

    public override void Validate()
    {
        ValidatePrice("Price");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidatePrice(string fieldName)
    {
        ValidationRules.ValidatePositive(_price, fieldName, this);
    }
}
