using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Address;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Shared.ValueObjects;

public sealed class AddressTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingAddress_ThenShouldInstantiateAddress()
    {
        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.NotNull(address);
    }

    [Fact]
    public void GivenValidStreet_WhenCreatingAddress_ThenShouldHaveValidStreet()
    {
        // Arrange
        const string expectedStreet = "Rua daquiasdasda";

        // Act
        var address = Address.Create(
            expectedStreet,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedStreet, address.Street);
    }

    [Fact]
    public void GivenValidNumber_WhenCreatingAddress_ThenShouldHaveValidNumber()
    {
        // Arrange
        const int expectedNumber = 123;

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            expectedNumber,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedNumber, address.Number);
    }

    [Fact]
    public void GivenValidComplement_WhenCreatingAddress_ThenShouldHaveValidComplement()
    {
        // Arrange
        const string expectedComplement = "Complement";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            expectedComplement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedComplement, address.Complement);
    }

    [Fact]
    public void GivenValidZipCode_WhenCreatingAddress_ThenShouldHaveValidZipCode()
    {
        // Arrange
        const string expectedZipCode = "22790147";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            expectedZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedZipCode, address.ZipCode);
    }

    [Fact]
    public void GivenValidNeighborhood_WhenCreatingAddress_ThenShouldHaveValidNeighborhood()
    {
        // Arrange
        const string expectedNeighborhood = "Neighborhood";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            expectedNeighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedNeighborhood, address.Neighborhood);
    }
    
    [Fact]
    public void GivenValidCity_WhenCreatingAddress_ThenShouldHaveValidCity()
    {
        // Arrange
        const string expectedCity = "City";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            expectedCity,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedCity, address.City);
    }

    [Fact]
    public void GivenValidState_WhenCreatingAddress_ThenShouldHaveValidState()
    {
        // Arrange
        const string expectedState = "State";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            expectedState,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedState, address.State);
    }

    [Fact]
    public void GivenValidCountry_WhenCreatingAddress_ThenShouldHaveValidCountry()
    {
        // Arrange
        const string expectedCountry = "Country";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
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
        const string expectedErrorMessage = "'Street' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    emptyStreet,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string expectedErrorMessage = "'Street' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    whitespaceStreet,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string expectedErrorMessage = "'Street' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    shortStreet,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string expectedErrorMessage = "'Street' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    longStreet,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const int invalidNumber = Constants.InvalidAddress.InvalidNumber;
        const string expectedErrorMessage = "'Number' should be a positive int.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    invalidNumber,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string longComplement = Constants.InvalidAddress.LongComplement;
        const string expectedErrorMessage = "'Complement' should be between 0 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    longComplement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string emptyZipCode = "";
        const string expectedErrorMessage = "'Zip Code' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    emptyZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string whitespaceZipCode = "        ";
        const string expectedErrorMessage = "'Zip Code' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    whitespaceZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string shortZipCode = Constants.InvalidAddress.ShortZipCode;
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    shortZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string longZipCode = Constants.InvalidAddress.LongZipCode;
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    longZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string nonNumericZipCode = Constants.InvalidAddress.NonNumericZipCode;
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    nonNumericZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string emptyNeighborhood = "";
        const string expectedErrorMessage = "'Neighborhood' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    emptyNeighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string whitespaceNeighborhood = "      ";
        const string expectedErrorMessage = "'Neighborhood' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    whitespaceNeighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string shortNeighborhood = Constants.InvalidAddress.ShortNeighborhood;
        const string expectedErrorMessage =
            "'Neighborhood' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    shortNeighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string longNeighborhood = Constants.InvalidAddress.LongNeighborhood;
        const string expectedErrorMessage =
            "'Neighborhood' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    longNeighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string emptyCity = "";
        const string expectedErrorMessage = "'City' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    emptyCity,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string whitespaceCity = "      ";
        const string expectedErrorMessage = "'City' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    whitespaceCity,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string shortCity = Constants.InvalidAddress.ShortCity;
        const string expectedErrorMessage = "'City' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    shortCity,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string longCity = Constants.InvalidAddress.LongCity;
        const string expectedErrorMessage = "'City' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    longCity,
                    Constants.Address.State,
                    Constants.Address.Country
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
        const string emptyState = "";
        const string expectedErrorMessage = "'State' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    emptyState,
                    Constants.Address.Country
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
        const string whitespaceState = "      ";
        const string expectedErrorMessage = "'State' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    whitespaceState,
                    Constants.Address.Country
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
        const string shortState = Constants.InvalidAddress.ShortState;
        const string expectedErrorMessage = "'State' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    shortState,
                    Constants.Address.Country
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
        const string longState = Constants.InvalidAddress.LongState;
        const string expectedErrorMessage = "'State' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    longState,
                    Constants.Address.Country
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
        const string emptyCountry = "";
        const string expectedErrorMessage = "'Country' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
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
        const string whitespaceCountry = "      ";
        const string expectedErrorMessage = "'Country' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
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
        const string shortCountry = Constants.InvalidAddress.ShortCountry;
        const string expectedErrorMessage = "'Country' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
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
        const string longCountry = Constants.InvalidAddress.LongCountry;
        const string expectedErrorMessage = "'Country' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Address.Create(
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
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
        const string expectedStreet = "Rua da praça";

        // Act
        var address = Address.Create(
            untrimmedStreet,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedStreet, address.Street);
    }

    [Fact]
    public void GivenUntrimmedComplement_WhenCreatingAddress_ThenShouldHaveTrimmedComplement()
    {
        // Arrange
        const string untrimmedComplement = "     Casa 75      ";
        const string expectedComplement = "Casa 75";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            untrimmedComplement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedComplement, address.Complement);
    }

    [Fact]
    public void GivenUntrimmedZipCode_WhenCreatingAddress_ThenShouldHaveTrimmedZipCode()
    {
        // Arrange
        const string untrimmedZipCode = " 87657-012 ";
        const string expectedZipCode = "87657012";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            untrimmedZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedZipCode, address.ZipCode);
    }

    [Fact]
    public void GivenUntrimmedNeighborhood_WhenCreatingAddress_ThenShouldHaveTrimmedNeighborhood()
    {
        // Arrange
        const string untrimmedNeighborhood = "    Barra da Tijuca     ";
        const string expectedNeighborhood = "Barra da Tijuca";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            untrimmedNeighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedNeighborhood, address.Neighborhood);
    }

    [Fact]
    public void GivenUntrimmedCity_WhenCreatingAddress_ThenShouldHaveTrimmedCity()
    {
        // Arrange
        const string untrimmedCity = "   São Paulo       ";
        const string expectedCity = "São Paulo";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            untrimmedCity,
            Constants.Address.State,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedCity, address.City);
    }

    [Fact]
    public void GivenUntrimmedState_WhenCreatingAddress_ThenShouldHaveTrimmedState()
    {
        // Arrange
        const string untrimmedState = "      Paraná    ";
        const string expectedState = "Paraná";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            untrimmedState,
            Constants.Address.Country
        );

        // Assert
        Assert.Equal(expectedState, address.State);
    }

    [Fact]
    public void GivenUntrimmedCountry_WhenCreatingAddress_ThenShouldHaveTrimmedCountry()
    {
        // Arrange
        const string untrimmedCountry = "       Itália  ";
        const string expectedCountry = "Itália";

        // Act
        var address = Address.Create(
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            untrimmedCountry
        );

        // Assert
        Assert.Equal(expectedCountry, address.Country);
    }

    [Fact]
    public void GivenValidAddress_WhenCallFormat_ShouldReturnFormattedAddress()
    {
        // Arrange
        var address = AddressFixture.CreateAddress();
        var expectedFormattedAddress = $"""
                                        {Constants.Address.Street}, {Constants.Address.Number}, {Constants.Address.Complement}
                                        {Constants.Address.Neighborhood}, {Constants.Address.City}, {Constants.Address.State}
                                        {Constants.Address.Country} - {Constants.Address.ZipCode.Replace("-", string.Empty)}
                                        """;

        // Act
        var formattedAddress = address.Format();

        // Assert
        Assert.Equal(expectedFormattedAddress, formattedAddress);
    }
}
