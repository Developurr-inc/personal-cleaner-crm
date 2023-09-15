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
        var newAddress = AddressFixture.CreateAddress(address: address);

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
        void Action()
        {
            _ = AddressFixture.CreateAddress(street: invalidStreet);
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
        void Action()
        {
            _ = AddressFixture.CreateAddress(number: invalidNumber);
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
        void Action()
        {
            _ = AddressFixture.CreateAddress(complement: invalidComplement);
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
        void Action()
        {
            _ = AddressFixture.CreateAddress(zipCode: invalidZipCode);
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
        void Action()
        {
            _ = AddressFixture.CreateAddress(neighborhood: invalidNeighborhood);
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
        void Action()
        {
            _ = AddressFixture.CreateAddress(city: invalidCity);
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
        void Action()
        {
            _ = AddressFixture.CreateAddress(state: invalidState);
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
        void Action()
        {
            _ = AddressFixture.CreateAddress(country: invalidCountry);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        AddressAssertion.AssertAddressException(exception!);
    }
}