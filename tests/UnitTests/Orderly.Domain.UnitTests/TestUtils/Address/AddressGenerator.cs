namespace Orderly.Domain.UnitTests.TestUtils.Address;

public sealed class AddressGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateAddresses()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                AddressFixture.CreateAddress()
            };
    }


    public static IEnumerable<object[]> CreateInvalidStreets()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                AddressFixture.CreateShortStreet()
            };

            yield return new object[]
            {
                AddressFixture.CreateLongStreet()
            };
        }
    }


    public static IEnumerable<object[]> CreateInvalidNumbers()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                AddressFixture.CreateNegativeNumber()
            };
    }


    public static IEnumerable<object[]> CreateInvalidComplements()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                AddressFixture.CreateLongComplement()
            };
    }


    public static IEnumerable<object[]> CreateInvalidZipCodes()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                AddressFixture.CreateShortZipCode()
            };

            yield return new object[]
            {
                AddressFixture.CreateLongZipCode()
            };
        }
    }


    public static IEnumerable<object[]> CreateInvalidNeighborhoods()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                AddressFixture.CreateShortNeighborhood()
            };

            yield return new object[]
            {
                AddressFixture.CreateLongNeighborhood()
            };
        }
    }


    public static IEnumerable<object[]> CreateInvalidCities()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                AddressFixture.CreateShortCity()
            };

            yield return new object[]
            {
                AddressFixture.CreateLongCity()
            };
        }
    }


    public static IEnumerable<object[]> CreateInvalidStates()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                AddressFixture.CreateShortState()
            };

            yield return new object[]
            {
                AddressFixture.CreateLongState()
            };
        }
    }


    public static IEnumerable<object[]> CreateInvalidCountries()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                AddressFixture.CreateShortCountry()
            };

            yield return new object[]
            {
                AddressFixture.CreateLongCountry()
            };
        }
    }
}