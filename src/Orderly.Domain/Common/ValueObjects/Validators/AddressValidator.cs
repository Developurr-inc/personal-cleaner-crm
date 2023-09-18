using Orderly.Domain.Validation;

namespace Orderly.Domain.Common.ValueObjects.Validators;

public sealed class AddressValidator : Validator
{
    private readonly string _street;
    private readonly int _number;
    private readonly string _complement;
    private readonly string _zipCode;
    private readonly string _neighborhood;
    private readonly string _city;
    private readonly string _state;
    private readonly string _country;

    public const int StreetMinLength = 3;
    public const int StreetMaxLength = 255;

    public const int ComplementMaxLength = 255;

    public const int ZipCodeMinLength = 3;
    public const int ZipCodeMaxLength = 10;

    public const int NeighborhoodMinLength = 3;
    public const int NeighborhoodMaxLength = 255;

    public const int CityMinLength = 3;
    public const int CityMaxLength = 255;

    public const int StateMinLength = 3;
    public const int StateMaxLength = 255;

    public const int CountryMinLength = 3;
    public const int CountryMaxLength = 255;

    public AddressValidator(
        string street,
        int number,
        string complement,
        string zipCode,
        string neighborhood,
        string city,
        string state,
        string country
    )
    {
        _street = street;
        _number = number;
        _complement = complement;
        _zipCode = zipCode;
        _neighborhood = neighborhood;
        _city = city;
        _state = state;
        _country = country;
    }

    public override void Validate()
    {
        ValidateStreet();
        ValidateNumber();
        ValidateComplement();
        ValidateZipCode();
        ValidateNeighborhood();
        ValidateCity();
        ValidateState();
        ValidateCountry();

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateStreet()
    {
        const string fieldName = "Street";

        ValidationRules.ValidateRequired(_street, fieldName, this);
        ValidationRules.ValidateStringLength(
            _street,
            fieldName,
            StreetMinLength,
            StreetMaxLength,
            this
        );
    }

    private void ValidateNumber()
    {
        const string fieldName = "Number";

        ValidationRules.ValidatePositive(_number, fieldName, this);
    }

    private void ValidateComplement()
    {
        const string fieldName = "Complement";

        ValidationRules.ValidateMaxStringLength(_complement, fieldName, ComplementMaxLength, this);
    }

    private void ValidateZipCode()
    {
        const string fieldName = "Zip Code";

        ValidationRules.ValidateRequired(_zipCode, fieldName, this);
        ValidationRules.ValidateStringLength(
            _zipCode,
            fieldName,
            ZipCodeMinLength,
            ZipCodeMaxLength,
            this
        );
    }

    private void ValidateNeighborhood()
    {
        const string fieldName = "Neighborhood";

        ValidationRules.ValidateRequired(_neighborhood, fieldName, this);
        ValidationRules.ValidateStringLength(
            _neighborhood,
            fieldName,
            NeighborhoodMinLength,
            NeighborhoodMaxLength,
            this
        );
    }

    private void ValidateCity()
    {
        const string fieldName = "City";

        ValidationRules.ValidateRequired(_city, fieldName, this);
        ValidationRules.ValidateStringLength(_city, fieldName, CityMinLength, CityMaxLength, this);
    }

    private void ValidateState()
    {
        const string fieldName = "State";

        ValidationRules.ValidateRequired(_state, fieldName, this);
        ValidationRules.ValidateStringLength(
            _state,
            fieldName,
            StateMinLength,
            StateMaxLength,
            this
        );
    }

    private void ValidateCountry()
    {
        const string fieldName = "Country";

        ValidationRules.ValidateRequired(_country, fieldName, this);
        ValidationRules.ValidateStringLength(
            _country,
            fieldName,
            CountryMinLength,
            CountryMaxLength,
            this
        );
    }
}
