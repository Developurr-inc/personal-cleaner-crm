namespace Orderly.Domain.Shipping.Validators;

public static class ShippingValidatorConfig
{
    public const int CorporateNameMinLength = 5;
    public const int CorporateNameMaxLength = 255;

    public const int TaxIdMinLength = 5;
    public const int TaxIdMaxLength = 255;

    public const int TradeNameMinLength = 5;
    public const int TradeNameMaxLength = 255;

    public const int SegmentMinLength = 5;
    public const int SegmentMaxLength = 255;
}
