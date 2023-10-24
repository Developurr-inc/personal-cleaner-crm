using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Address;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.ZipCode;

namespace Developurr.Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class AddressTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingAddress_ThenShouldInstantiateAddress()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        
        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.NotNull(address);
    }

    [Fact]
    public void GivenValidStreet_WhenCreatingAddress_ThenShouldHaveValidStreet()
    {
        // Arrange
        const string expectedStreet = "Rua daquiasdasda";
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var address = Address.Create(
            expectedStreet,
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedStreet, address.Street);
    }

    [Fact]
    public void GivenValidNumber_WhenCreatingAddress_ThenShouldHaveValidNumber()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int expectedNumber = 123;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var address = Address.Create(
            street.ToString(),
            expectedNumber,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedNumber, address.Number);
    }

    [Fact]
    public void GivenValidComplement_WhenCreatingAddress_ThenShouldHaveValidComplement()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        const string expectedComplement = "Complement";
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            expectedComplement,
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedComplement, address.Complement);
    }

    [Fact]
    public void GivenValidZipCode_WhenCreatingAddress_ThenShouldHaveValidZipCode()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        const string expectedZipCode = "22790147";
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            expectedZipCode,
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedZipCode, address.ZipCode);
    }

    [Fact]
    public void GivenValidNeighborhood_WhenCreatingAddress_ThenShouldHaveValidNeighborhood()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        const string expectedNeighborhood = "Neighborhood";
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            expectedNeighborhood,
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedNeighborhood, address.Neighborhood);
    }

    [Fact]
    public void GivenValidCity_WhenCreatingAddress_ThenShouldHaveValidCity()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedCity = "City";
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            expectedCity,
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedCity, address.City);
    }

    [Fact]
    public void GivenValidState_WhenCreatingAddress_ThenShouldHaveValidState()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedState = "State";
        var country = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            expectedState,
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedState, address.State);
    }

    [Fact]
    public void GivenValidCountry_WhenCreatingAddress_ThenShouldHaveValidCountry()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedCountry = "Country";

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            expectedCountry
        );

        // Assert
        Assert.Equal(expectedCountry, address.Country);
    }

    [Theory]
    [InlineData("", 123, "complement", "12345-678", "Neighborhood", "City", "State", "Country")]
    [InlineData(
        "Street",
        -1,
        "complement",
        "12345-678",
        "Neighborhood",
        "City",
        "State",
        "Country"
    )]
    [InlineData("Street", 123, "complement", "", "Neighborhood", "City", "State", "Country")]
    [InlineData("Street", 123, "complement", "12345-678", "", "City", "State", "Country")]
    [InlineData("Street", 123, "complement", "12345-678", "Neighborhood", "", "State", "Country")]
    [InlineData("Street", 123, "complement", "12345-678", "Neighborhood", "City", "", "Country")]
    [InlineData("Street", 123, "complement", "12345-678", "Neighborhood", "City", "State", "")]
    public void GivenInvalidInput_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage(
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
        // Arrange
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street,
                    number,
                    complement,
                    zipCode,
                    neighborhood,
                    city,
                    state,
                    country
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenEmptyStreet_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyStreet = "";
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Street' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    emptyStreet,
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespaceStreet_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceStreet = "             ";
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Street' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    whitespaceStreet,
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortStreet_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortStreet = Constants.InvalidAddress.ShortStreet;
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Street' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    shortStreet,
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongStreet_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longStreet = Constants.InvalidAddress.LongStreet;
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Street' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    longStreet,
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenInvalidNumber_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int invalidNumber = Constants.InvalidAddress.InvalidNumber;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Number' should be a positive int.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    invalidNumber,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongComplement_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        const string longComplement = Constants.InvalidAddress.LongComplement;
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Complement' should be between 0 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    longComplement,
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenEmptyZipCode_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        const string emptyZipCode = "";
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Zip Code' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    emptyZipCode,
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespaceZipCode_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        const string whitespaceZipCode = "        ";
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Zip Code' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    whitespaceZipCode,
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortZipCode_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        const string shortZipCode = Constants.InvalidAddress.ShortZipCode;
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    shortZipCode,
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongZipCode_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        const string longZipCode = Constants.InvalidAddress.LongZipCode;
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    longZipCode,
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenNonNumericZipCode_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        const string nonNumericZipCode = Constants.InvalidAddress.NonNumericZipCode;
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    nonNumericZipCode,
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenEmptyNeighborhood_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        const string emptyNeighborhood = "";
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Neighborhood' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    emptyNeighborhood,
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespaceNeighborhood_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        const string whitespaceNeighborhood = "      ";
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'Neighborhood' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    whitespaceNeighborhood,
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortNeighborhood_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        const string shortNeighborhood = Constants.InvalidAddress.ShortNeighborhood;
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage =
            "'Neighborhood' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    shortNeighborhood,
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongNeighborhood_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        const string longNeighborhood = Constants.InvalidAddress.LongNeighborhood;
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage =
            "'Neighborhood' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    longNeighborhood,
                    city.ToString(),
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenEmptyCity_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        const string emptyCity = "";
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'City' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    emptyCity,
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespaceCity_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        const string whitespaceCity = "      ";
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'City' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    whitespaceCity,
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortCity_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        const string shortCity = Constants.InvalidAddress.ShortCity;
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'City' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    shortCity,
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongCity_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        const string longCity = Constants.InvalidAddress.LongCity;
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'City' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    longCity,
                    state.ToString(),
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenEmptyState_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        const string emptyState = "";
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'State' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    emptyState,
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespaceState_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        const string whitespaceState = "      ";
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'State' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    whitespaceState,
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortState_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        const string shortState = Constants.InvalidAddress.ShortState;
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'State' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    shortState,
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongState_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        const string longState = Constants.InvalidAddress.LongState;
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedErrorMessage = "'State' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    longState,
                    country.ToString()
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenEmptyCountry_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        const string emptyCountry = "";
        const string expectedErrorMessage = "'Country' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    emptyCountry
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespaceCountry_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        const string whitespaceCountry = "      ";
        const string expectedErrorMessage = "'Country' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    whitespaceCountry
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortCountry_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        const string shortCountry = Constants.InvalidAddress.ShortCountry;
        const string expectedErrorMessage = "'Country' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    shortCountry
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongCountry_WhenCreatingAddress_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        const string longCountry = Constants.InvalidAddress.LongCountry;
        const string expectedErrorMessage = "'Country' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    street.ToString(),
                    number,
                    complement.ToString(),
                    zipCode.ToString(),
                    neighborhood.ToString(),
                    city.ToString(),
                    state.ToString(),
                    longCountry
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenUntrimmedStreet_WhenCreatingAddress_ThenShouldHaveTrimmedStreet()
    {
        // Arrange
        const string untrimmedStreet = "    Rua da praça       ";
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedStreet = "Rua da praça";

        // Act
        var address = Address.Create(
            untrimmedStreet,
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedStreet, address.Street);
    }

    [Fact]
    public void GivenUntrimmedComplement_WhenCreatingAddress_ThenShouldHaveTrimmedComplement()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        const string untrimmedComplement = "     Casa 75      ";
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedComplement = "Casa 75";

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            untrimmedComplement,
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedComplement, address.Complement);
    }

    [Fact]
    public void GivenUntrimmedZipCode_WhenCreatingAddress_ThenShouldHaveTrimmedZipCode()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        const string untrimmedZipCode = " 87657-012 ";
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedZipCode = "87657012";

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            untrimmedZipCode,
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedZipCode, address.ZipCode);
    }

    [Fact]
    public void GivenUntrimmedNeighborhood_WhenCreatingAddress_ThenShouldHaveTrimmedNeighborhood()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        const string untrimmedNeighborhood = "    Barra da Tijuca     ";
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedNeighborhood = "Barra da Tijuca";

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            untrimmedNeighborhood,
            city.ToString(),
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedNeighborhood, address.Neighborhood);
    }

    [Fact]
    public void GivenUntrimmedCity_WhenCreatingAddress_ThenShouldHaveTrimmedCity()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        const string untrimmedCity = "   São Paulo       ";
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedCity = "São Paulo";

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            untrimmedCity,
            state.ToString(),
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedCity, address.City);
    }

    [Fact]
    public void GivenUntrimmedState_WhenCreatingAddress_ThenShouldHaveTrimmedState()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        const string untrimmedState = "      Paraná    ";
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        const string expectedState = "Paraná";

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            untrimmedState,
            country.ToString()
        );

        // Assert
        Assert.Equal(expectedState, address.State);
    }

    [Fact]
    public void GivenUntrimmedCountry_WhenCreatingAddress_ThenShouldHaveTrimmedCountry()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        const string untrimmedCountry = "       Itália  ";
        const string expectedCountry = "Itália";

        // Act
        var address = Address.Create(
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            expectedCountry
        );

        // Assert
        Assert.Equal(expectedCountry, address.Country);
    }

    [Fact]
    public void GivenValidAddress_WhenCallFormat_ShouldReturnFormattedAddress()
    {
        // Arrange
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        var zipCode = ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        var address = Address.Create(street, number, complement, zipCode.ToString(), neighborhood, city, state,
            country);
        var expectedFormattedAddress = $"""
                                        {street}, {number}, {complement}
                                        {neighborhood}, {city}, {state}
                                        {country} - {zipCode.ToString().Replace("-", string.Empty)}
                                        """;
        // Act
        var formattedAddress = address.Format();

        // Assert
        Assert.Equal(expectedFormattedAddress, formattedAddress);
    }
}
