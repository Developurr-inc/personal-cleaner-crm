using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Customer.Validators;

public sealed class CustomerValidator : Validator
{
    private readonly string _corporateName;
    private readonly string _taxId;
    private readonly string _tradeName;
    private readonly string _segment;
    private readonly string _observation;

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
        ValidateCorporateName("Corporate Name");
        ValidateTaxId("Tax ID");
        ValidateTradeName("Trade Name");
        ValidateSegment("Segment");
        ValidateObservation("Observation");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateCorporateName(string fieldName)
    {
        ValidationRules.ValidateRequired(_corporateName, fieldName, this);
        ValidationRules.ValidateStringLength(
            _corporateName,
            fieldName,
            CustomerValidatorConfig.CorporateNameMinLength,
            CustomerValidatorConfig.CorporateNameMaxLength,
            this
        );
    }

    private void ValidateTaxId(string fieldName)
    {
        ValidationRules.ValidateRequired(_taxId, fieldName, this);
        ValidationRules.ValidateStringLength(
            _taxId,
            fieldName,
            CustomerValidatorConfig.TaxIdMinLength,
            CustomerValidatorConfig.TaxIdMaxLength,
            this
        );
    }

    private void ValidateTradeName(string fieldName)
    {
        ValidationRules.ValidateRequired(_tradeName, fieldName, this);
        ValidationRules.ValidateStringLength(
            _tradeName,
            fieldName,
            CustomerValidatorConfig.TradeNameMinLength,
            CustomerValidatorConfig.TradeNameMaxLength,
            this
        );
    }

    private void ValidateSegment(string fieldName)
    {
        ValidationRules.ValidateRequired(_segment, fieldName, this);
        ValidationRules.ValidateStringLength(
            _segment,
            fieldName,
            CustomerValidatorConfig.SegmentMinLength,
            CustomerValidatorConfig.SegmentMaxLength,
            this
        );
    }

    private void ValidateObservation(string fieldName)
    {
        ValidationRules.ValidateMaxStringLength(
            _observation,
            fieldName,
            CustomerValidatorConfig.ObservationMaxLength,
            this
        );
    }
}
