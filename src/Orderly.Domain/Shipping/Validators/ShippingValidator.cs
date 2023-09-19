using Orderly.Domain.Validation;

namespace Orderly.Domain.Shipping.Validators;

public sealed class ShippingValidator : Validator
{
    private readonly string _corporateName;
    private readonly string _taxId;
    private readonly string _tradeName;
    private readonly string _segment;

    public const int CorporateNameMinLength = 5;
    public const int CorporateNameMaxLength = 255;

    public const int TaxIdMinLength = 5;
    public const int TaxIdMaxLength = 255;

    public const int TradeNameMinLength = 5;
    public const int TradeNameMaxLength = 255;

    public const int SegmentMinLength = 5;
    public const int SegmentMaxLength = 255;
    
    public ShippingValidator(
        string corporateName,
        string taxId,
        string tradeName,
        string segment
    )
    {
        _corporateName = corporateName;
        _taxId = taxId;
        _tradeName = tradeName;
        _segment = segment;
    }
    
    
    public override void Validate()
    {
        ValidateCorporateName();
        ValidateTaxId();
        ValidateTradeName();
        ValidateSegment();

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }
    
    
    private void ValidateCorporateName()
    {
        const string fieldName = "Corporate Name";

        ValidationRules.ValidateRequired(_corporateName, fieldName, this);
        ValidationRules.ValidateStringLength(
            _corporateName,
            fieldName,
            CorporateNameMinLength,
            CorporateNameMaxLength,
            this
        );
    }
    
    
    private void ValidateTaxId()
    {
        const string fieldName = "Tax ID";

        ValidationRules.ValidateRequired(_taxId, fieldName, this);
        ValidationRules.ValidateStringLength(
            _taxId,
            fieldName,
            TaxIdMinLength,
            TaxIdMaxLength,
            this
        );
    }
    
    
    private void ValidateTradeName()
    {
        const string fieldName = "Trade Name";

        ValidationRules.ValidateRequired(_tradeName, fieldName, this);
        ValidationRules.ValidateStringLength(
            _tradeName,
            fieldName,
            TradeNameMinLength,
            TradeNameMaxLength,
            this
        );
    }
    
    
    private void ValidateSegment()
    {
        const string fieldName = "Segment";

        ValidationRules.ValidateRequired(_segment, fieldName, this);
        ValidationRules.ValidateStringLength(
            _segment,
            fieldName,
            SegmentMinLength,
            SegmentMaxLength,
            this
        );
    }
}