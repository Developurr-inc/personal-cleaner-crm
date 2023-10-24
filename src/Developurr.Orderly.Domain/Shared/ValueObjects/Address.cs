using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class Address : ValueObject
{
    public string Street { get; }
    public int Number { get; }
    public string Complement { get; }
    public string ZipCode { get; }
    public string Neighborhood { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }

    private Address() { }

    private Address(
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
        Street = street;
        Number = number;
        Complement = complement;
        ZipCode = zipCode.Replace("-", string.Empty);
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
    }

    public static Address Create(
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
        var streetTrimmed = street.Trim();
        var complementTrimmed = complement.Trim();
        var zipCodeTrimmed = zipCode.Trim();
        var neighborhoodTrimmed = neighborhood.Trim();
        var cityTrimmed = city.Trim();
        var stateTrimmed = state.Trim();
        var countryTrimmed = country.Trim();

        var addressValidator = new AddressValidator(
            streetTrimmed,
            number,
            complementTrimmed,
            zipCodeTrimmed,
            neighborhoodTrimmed,
            cityTrimmed,
            stateTrimmed,
            countryTrimmed
        );
        addressValidator.Validate();

        return new Address(
            streetTrimmed,
            number,
            complementTrimmed,
            zipCodeTrimmed,
            neighborhoodTrimmed,
            cityTrimmed,
            stateTrimmed,
            countryTrimmed
        );
    }

    public string Format()
    {
        return $"""
                {Street}, {Number}, {Complement}
                {Neighborhood}, {City}, {State}
                {Country} - {ZipCode}
                """;
    }

    public override string ToString()
    {
        return Format();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Number;
        yield return Complement;
        yield return ZipCode;
        yield return Neighborhood;
        yield return City;
        yield return State;
        yield return Country;
    }
}
