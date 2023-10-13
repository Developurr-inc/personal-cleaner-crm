namespace Developurr.Orderly.Domain.Customer.Validators;

public static class CustomerValidatorConfig
{
    public const int CorporateNameMinLength = 5;
    public const int CorporateNameMaxLength = 255;

    public const int TaxIdMinLength = 5;
    public const int TaxIdMaxLength = 255;

    public const int TradeNameMinLength = 5;
    public const int TradeNameMaxLength = 255;

    public const int SegmentMinLength = 5;
    public const int SegmentMaxLength = 255;

    public const int ObservationMaxLength = 10_000;
}
