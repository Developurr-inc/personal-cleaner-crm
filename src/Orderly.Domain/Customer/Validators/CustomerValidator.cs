using Orderly.Domain.Validation;

namespace Orderly.Domain.Customer.Validators;

public sealed class CustomerValidator : Validator
{
    private readonly string _corporateName;
    private readonly string _taxId;
    private readonly string _tradeName;
    private readonly string _segment;
    private readonly string _observation;

    public const int CorporateNameMinLength = 5;
    public const int CorporateNameMaxLength = 255;

    public const int TaxIdMinLength = 5;
    public const int TaxIdMaxLength = 255;

    public const int TradeNameMinLength = 5;
    public const int TradeNameMaxLength = 255;

    public const int SegmentMinLength = 5;
    public const int SegmentMaxLength = 255;

    public const int ObservationMaxLength = 10_000;

    public CustomerValidator(
        string corporateName,
        string taxId,
        string tradeName,
        string segment,
        string observation
    )
    {
        _corporateName = corporateName;
        _taxId = taxId;
        _tradeName = tradeName;
        _segment = segment;
        _observation = observation;
    }

    public override void Validate()
    {
        ValidateCorporateName();
        ValidateTaxId();
        ValidateTradeName();
        ValidateSegment();
        ValidateObservation();

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

    private void ValidateObservation()
    {
        const string fieldName = "Observation";

        ValidationRules.ValidateMaxStringLength(
            _observation,
            fieldName,
            ObservationMaxLength,
            this
        );
    }
}
