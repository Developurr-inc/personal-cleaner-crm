using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

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
        ValidateStreet("Street");
        ValidateNumber("Number");
        ValidateComplement("Complement");
        ValidateZipCode("Zip Code");
        ValidateNeighborhood("Neighborhood");
        ValidateCity("City");
        ValidateState("State");
        ValidateCountry("Country");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateStreet(string fieldName)
    {
        ValidationRules.ValidateRequired(_street, fieldName, this);
        ValidationRules.ValidateStringLength(
            _street,
            fieldName,
            AddressValidatorConfig.StreetMinLength,
            AddressValidatorConfig.StreetMaxLength,
            this
        );
    }

    private void ValidateNumber(string fieldName)
    {
        ValidationRules.ValidatePositive(_number, fieldName, this);
    }

    private void ValidateComplement(string fieldName)
    {
        ValidationRules.ValidateMaxStringLength(
            _complement,
            fieldName,
            AddressValidatorConfig.ComplementMaxLength,
            this
        );
    }

    private void ValidateZipCode(string fieldName)
    {
        ValidationRules.ValidateRequired(_zipCode, fieldName, this);
        ValidationRules.ValidateZipCode(_zipCode, fieldName, this);
    }

    private void ValidateNeighborhood(string fieldName)
    {
        ValidationRules.ValidateRequired(_neighborhood, fieldName, this);
        ValidationRules.ValidateStringLength(
            _neighborhood,
            fieldName,
            AddressValidatorConfig.NeighborhoodMinLength,
            AddressValidatorConfig.NeighborhoodMaxLength,
            this
        );
    }

    private void ValidateCity(string fieldName)
    {
        ValidationRules.ValidateRequired(_city, fieldName, this);
        ValidationRules.ValidateStringLength(
            _city,
            fieldName,
            AddressValidatorConfig.CityMinLength,
            AddressValidatorConfig.CityMaxLength,
            this
        );
    }

    private void ValidateState(string fieldName)
    {
        ValidationRules.ValidateRequired(_state, fieldName, this);
        ValidationRules.ValidateStringLength(
            _state,
            fieldName,
            AddressValidatorConfig.StateMinLength,
            AddressValidatorConfig.StateMaxLength,
            this
        );
    }

    private void ValidateCountry(string fieldName)
    {
        ValidationRules.ValidateRequired(_country, fieldName, this);
        ValidationRules.ValidateStringLength(
            _country,
            fieldName,
            AddressValidatorConfig.CountryMinLength,
            AddressValidatorConfig.CountryMaxLength,
            this
        );
    }
}
