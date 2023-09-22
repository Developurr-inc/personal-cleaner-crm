using Orderly.Domain.Validation;

namespace Orderly.Domain.Shipping.Validators;

public sealed class ShippingValidator : Validator
{
    private readonly string _corporateName;
    private readonly string _taxId;
    private readonly string _tradeName;
    private readonly string _segment;

    public ShippingValidator(string corporateName, string taxId, string tradeName, string segment)
    {
        _corporateName = corporateName;
        _taxId = taxId;
        _tradeName = tradeName;
        _segment = segment;
    }

    public override void Validate()
    {
        ValidateCorporateName("Corporate Name");
        ValidateTaxId("Tax ID");
        ValidateTradeName("Trade Name");
        ValidateSegment("Segment");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateCorporateName(string fieldName)
    {
        ValidationRules.ValidateRequired(_corporateName, fieldName, this);
        ValidationRules.ValidateStringLength(
            _corporateName,
            fieldName,
            ShippingValidatorConfig.CorporateNameMinLength,
            ShippingValidatorConfig.CorporateNameMaxLength,
            this
        );
    }

    private void ValidateTaxId(string fieldName)
    {
        ValidationRules.ValidateRequired(_taxId, fieldName, this);
        ValidationRules.ValidateStringLength(
            _taxId,
            fieldName,
            ShippingValidatorConfig.TaxIdMinLength,
            ShippingValidatorConfig.TaxIdMaxLength,
            this
        );
    }

    private void ValidateTradeName(string fieldName)
    {
        ValidationRules.ValidateRequired(_tradeName, fieldName, this);
        ValidationRules.ValidateStringLength(
            _tradeName,
            fieldName,
            ShippingValidatorConfig.TradeNameMinLength,
            ShippingValidatorConfig.TradeNameMaxLength,
            this
        );
    }

    private void ValidateSegment(string fieldName)
    {
        ValidationRules.ValidateRequired(_segment, fieldName, this);
        ValidationRules.ValidateStringLength(
            _segment,
            fieldName,
            ShippingValidatorConfig.SegmentMinLength,
            ShippingValidatorConfig.SegmentMaxLength,
            this
        );
    }
}
