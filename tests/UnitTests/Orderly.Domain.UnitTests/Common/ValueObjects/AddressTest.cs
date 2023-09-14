using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Address;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class AddressTest
{
    [Theory]
    [MemberData(nameof(AddressGenerator.CreateAddresses), MemberType = typeof(AddressGenerator))]
    public void GivenValidInput_WhenCreatingAddress_ThenShouldInstantiateAddress(
        Address address
    )
    {
        // Act
        var newAddress = Address.Create(
            address.Street,
            address.Number,
            address.Complement,
            address.ZipCode,
            address.Neighborhood,
            address.City,
            address.State,
            address.Country
        );

        // Assert
        AddressAssertion.AssertAddress(address, newAddress);
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidStreets), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidStreet_WhenCreatingAddress_ThenShouldThrowEntityValidationException(
        string invalidStreet
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();

        void Action()
        {
            _ = Address.Create(
                invalidStreet,
                address.Number,
                address.Complement,
                address.ZipCode,
                address.Neighborhood,
                address.City,
                address.State,
                address.Country
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidNumbers), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidNumber_WhenCreatingAddress_ThenShouldThrowEntityValidationException(
        int invalidNumber
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();

        void Action()
        {
            _ = Address.Create(
                address.Street,
                invalidNumber,
                address.Complement,
                address.ZipCode,
                address.Neighborhood,
                address.City,
                address.State,
                address.Country
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidComplements), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidComplement_WhenCreatingAddress_ThenShouldThrowEntityValidationException(
        string invalidComplement
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        
        void Action()
        {
            _ = Address.Create(
                address.Street,
                address.Number,
                invalidComplement,
                address.ZipCode,
                address.Neighborhood,
                address.City,
                address.State,
                address.Country
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidZipCodes), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidZipCode_WhenCreatingAddress_ThenShouldThrowEntityValidationException(
        string invalidZipCode
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();

        void Action()
        {
            _ = Address.Create(
                address.Street,
                address.Number,
                address.Complement,
                invalidZipCode,
                address.Neighborhood,
                address.City,
                address.State,
                address.Country
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidNeighborhoods), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidNeighborhood_WhenCreatingAddress_ThenShouldThrowEntityValidationException(
        string invalidNeighborhood
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();

        void Action()
        {
            _ = Address.Create(
                address.Street,
                address.Number,
                address.Complement,
                address.ZipCode,
                invalidNeighborhood,
                address.City,
                address.State,
                address.Country
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidCities), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidCity_WhenCreatingAddress_ThenShouldThrowEntityValidationException(
        string invalidCity
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();

        void Action()
        {
            _ = Address.Create(
                address.Street,
                address.Number,
                address.Complement,
                address.ZipCode,
                address.Neighborhood,
                invalidCity,
                address.State,
                address.Country
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidStates), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidState_WhenCreatingAddress_ThenShouldThrowEntityValidationException(
        string invalidState
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();

        void Action()
        {
            _ = Address.Create(
                address.Street,
                address.Number,
                address.Complement,
                address.ZipCode,
                address.Neighborhood,
                address.City,
                invalidState,
                address.Country
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidCountries), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidCountry_WhenCreatingAddress_ThenShouldThrowEntityValidationException(
        string invalidCountry
    )
    {
        // Arrange
        var address = AddressFixture.CreateAddress();

        void Action()
        {
            _ = Address.Create(
                address.Street,
                address.Number,
                address.Complement,
                address.ZipCode,
                address.Neighborhood,
                address.City,
                address.State,
                invalidCountry
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }
}