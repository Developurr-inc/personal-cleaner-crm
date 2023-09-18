using Orderly.Domain.Validation;

namespace Orderly.Domain.Common.ValueObjects.Validators;

public sealed class PriceValidator : Validator
{
    private readonly decimal _price;

    public PriceValidator(decimal price)
    {
        _price = price;
    }

    public override void Validate()
    {
        ValidatePrice();

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidatePrice()
    {
        const string fieldName = "Price";

        ValidationRules.ValidatePositive(_price, fieldName, this);
    }
}
