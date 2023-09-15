using Orderly.Domain.Common.ValueObjects.Validators;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Address;

public sealed class AddressFixture : BaseFixture
{
    private static Domain.Common.ValueObjects.Address CreateValidAddress()
    {
        var street = Faker.Address.StreetName();
        var number = int.Parse(Faker.Address.BuildingNumber());
        var complement = Faker.Address.SecondaryAddress();
        var zipCode = Faker.Address.ZipCode();
        var neighborhood = Faker.Address.County();
        var city = Faker.Address.City();
        var state = Faker.Address.State();
        var country = Faker.Address.Country();

        return Domain.Common.ValueObjects.Address.Create(
            street,
            number,
            complement,
            zipCode,
            neighborhood,
            city,
            state,
            country
        );
    }

    public static Domain.Common.ValueObjects.Address CreateAddress(
        Domain.Common.ValueObjects.Address? address = null,
        string? street = null,
        int? number = null,
        string? complement = null,
        string? zipCode = null,
        string? neighborhood = null,
        string? city = null,
        string? state = null,
        string? country = null
    )
    {
        var lAddress = address ?? CreateValidAddress();

        return Domain.Common.ValueObjects.Address.Create(
            street ?? lAddress.Street,
            number ?? lAddress.Number,
            complement ?? lAddress.Complement,
            zipCode ?? lAddress.ZipCode,
            neighborhood ?? lAddress.Neighborhood,
            city ?? lAddress.City,
            state ?? lAddress.State,
            country ?? lAddress.Country
        );
    }

    public static string CreateShortStreet()
    {
        return StringFixture.CreateString(1, AddressValidator.StreetMinLength - 1);
    }

    public static string CreateLongStreet()
    {
        return StringFixture.CreateString(AddressValidator.StreetMaxLength + 1, 1_000);
    }

    public static int CreateNegativeNumber()
    {
        return -Faker.Random.Number(99_999);
    }

    public static string CreateLongComplement()
    {
        return StringFixture.CreateString(AddressValidator.ComplementMaxLength + 1, 1_000);
    }

    public static string CreateShortZipCode()
    {
        return StringFixture.CreateString(1, AddressValidator.ZipCodeMinLength - 1);
    }

    public static string CreateLongZipCode()
    {
        return StringFixture.CreateString(AddressValidator.ZipCodeMaxLength + 1, 1_000);
    }

    public static string CreateShortNeighborhood()
    {
        return StringFixture.CreateString(1, AddressValidator.NeighborhoodMinLength - 1);
    }

    public static string CreateLongNeighborhood()
    {
        return StringFixture.CreateString(AddressValidator.NeighborhoodMaxLength + 1, 1_000);
    }

    public static string CreateShortCity()
    {
        return StringFixture.CreateString(1, AddressValidator.CityMinLength - 1);
    }

    public static string CreateLongCity()
    {
        return StringFixture.CreateString(AddressValidator.CityMaxLength + 1, 1_000);
    }

    public static string CreateShortState()
    {
        return StringFixture.CreateString(1, AddressValidator.StateMinLength - 1);
    }

    public static string CreateLongState()
    {
        return StringFixture.CreateString(AddressValidator.StateMaxLength + 1, 1_000);
    }

    public static string CreateShortCountry()
    {
        return StringFixture.CreateString(1, AddressValidator.CountryMinLength - 1);
    }

    public static string CreateLongCountry()
    {
        return StringFixture.CreateString(AddressValidator.CountryMaxLength + 1, 1_000);
    }
}
