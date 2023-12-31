namespace Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

public static class AddressValidatorConfig
{
    public const int StreetMinLength = 3;
    public const int StreetMaxLength = 255;

    public const int ComplementMaxLength = 255;

    public const int NeighborhoodMinLength = 3;
    public const int NeighborhoodMaxLength = 255;

    public const int CityMinLength = 3;
    public const int CityMaxLength = 255;

    public const int StateMinLength = 3;
    public const int StateMaxLength = 255;

    public const int CountryMinLength = 3;
    public const int CountryMaxLength = 255;
}
