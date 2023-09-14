using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Address;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class AddressTest
{
    [Theory]
    [MemberData(
        nameof(AddressGenerator.CreateAddresses),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingAddress_GivenValidInput_ShouldInstantiateAddress(
        Address address
    )
    {
        // Arrange
        var street = address.Street;
        var number = address.Number;
        var complement = address.Complement;
        var zipCode = address.ZipCode;
        var neighborhood = address.Neighborhood;
        var city = address.City;
        var state = address.State;
        var country = address.Country;


        // Act
        var newAddress = Address.Create(
            street,
            number,
            complement,
            zipCode,
            neighborhood,
            city,
            state,
            country
        );

        //Assert
        AddressAssertion.AssertAddress(address, newAddress);
    }


    [Theory]
    [MemberData(
        nameof(AddressGenerator.CreateInvalidStreets),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingAddress_GivenInvalidStreet_ShouldThrowException(
        string invalidStreet
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        var street = invalidStreet;
        var number = address.Number;
        var complement = address.Complement;
        var zipCode = address.ZipCode;
        var neighborhood = address.Neighborhood;
        var city = address.City;
        var state = address.State;
        var country = address.Country;

        void Action()
        {
            _ = Address.Create(
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

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(
        nameof(AddressGenerator.CreateInvalidNumbers),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingAddress_GivenInvalidNumber_ShouldThrowException(
        int invalidNumber
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        var street = address.Street;
        var number = invalidNumber;
        var complement = address.Complement;
        var zipCode = address.ZipCode;
        var neighborhood = address.Neighborhood;
        var city = address.City;
        var state = address.State;
        var country = address.Country;

        void Action()
        {
            _ = Address.Create(
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

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(
        nameof(AddressGenerator.CreateInvalidComplements),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingAddress_GivenInvalidComplement_ShouldThrowException(
        string invalidComplement
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        var street = address.Street;
        var number = address.Number;
        var complement = invalidComplement;
        var zipCode = address.ZipCode;
        var neighborhood = address.Neighborhood;
        var city = address.City;
        var state = address.State;
        var country = address.Country;

        void Action()
        {
            _ = Address.Create(
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

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(
        nameof(AddressGenerator.CreateInvalidZipCodes),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingAddress_GivenInvalidZipCode_ShouldThrowException(
        string invalidZipCode
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        var street = address.Street;
        var number = address.Number;
        var complement = address.Complement;
        var zipCode = invalidZipCode;
        var neighborhood = address.Neighborhood;
        var city = address.City;
        var state = address.State;
        var country = address.Country;

        void Action()
        {
            _ = Address.Create(
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

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(
        nameof(AddressGenerator.CreateInvalidNeighborhoods),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingAddress_GivenInvalidNeighborhoodShouldThrowException(
        string invalidNeighborhood
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        var street = address.Street;
        var number = address.Number;
        var complement = address.Complement;
        var zipCode = address.ZipCode;
        var neighborhood = invalidNeighborhood;
        var city = address.City;
        var state = address.State;
        var country = address.Country;

        void Action()
        {
            _ = Address.Create(
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

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(
        nameof(AddressGenerator.CreateInvalidCities),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingAddress_GivenInvalidCity_ShouldThrowException(
        string invalidCity
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        var street = address.Street;
        var number = address.Number;
        var complement = address.Complement;
        var zipCode = address.ZipCode;
        var neighborhood = address.Neighborhood;
        var city = invalidCity;
        var state = address.State;
        var country = address.Country;

        void Action()
        {
            _ = Address.Create(
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

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(
        nameof(AddressGenerator.CreateInvalidStates),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingAddress_GivenInvalidState_ShouldThrowException(
        string invalidState
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        var street = address.Street;
        var number = address.Number;
        var complement = address.Complement;
        var zipCode = address.ZipCode;
        var neighborhood = address.Neighborhood;
        var city = address.City;
        var state = invalidState;
        var country = address.Country;

        void Action()
        {
            _ = Address.Create(
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

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(
        nameof(AddressGenerator.CreateInvalidCountries),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingAddress_GivenInvalidCountry_ShouldThrowException(
        string invalidCountry
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        var street = address.Street;
        var number = address.Number;
        var complement = address.Complement;
        var zipCode = address.ZipCode;
        var neighborhood = address.Neighborhood;
        var city = address.City;
        var state = address.State;
        var country = invalidCountry;

        void Action()
        {
            _ = Address.Create(
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

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }
}