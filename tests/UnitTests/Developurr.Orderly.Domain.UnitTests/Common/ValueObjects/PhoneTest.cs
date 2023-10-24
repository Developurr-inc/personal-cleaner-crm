using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class PhoneTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingPhone_ThenShouldInstantiatePhone()
    {
        // Act
        var phone = Phone.Create(Constants.Phone.PhoneValue);

        // Assert
        Assert.NotNull(phone);
    }

    [Fact]
    public void GivenValidPhoneValue_WhenCreatingPhone_ThenShouldHaveValidPhoneValue()
    {
        // Arrange
        const string expectedPhoneValue = "21998345677";

        // Act
        var phone = Phone.Create(Constants.Phone.PhoneValue);

        // Assert
        Assert.Equal(expectedPhoneValue, phone.Value);
    }

    [Fact]
    public void GivenInvalidInput_WhenCreatingPhone_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidPhone = "";
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(() => Phone.Create(invalidPhone));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenEmptyPhoneValue_WhenCreatingPhone_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string emptyPhoneValue = "";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(() => Phone.Create(emptyPhoneValue));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespacePhoneValue_WhenCreatingPhone_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string whitespacePhoneValue = "                  ";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(() => Phone.Create(whitespacePhoneValue));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortPhoneValue_WhenCreatingPhone_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string shortPhoneValue = Constants.InvalidPhone.ShortPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(() => Phone.Create(shortPhoneValue));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongPhoneValue_WhenCreatingPhone_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string longPhoneValue = Constants.InvalidPhone.LongPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(() => Phone.Create(longPhoneValue));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenNonNumericPhone_WhenCreatingPhone_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericPhone = Constants.InvalidPhone.NonNumericPhone;
        const string expectedErrorMessage = "'Phone Number' is not valid.";

        // Act
        var exception = Record.Exception(() => Phone.Create(nonNumericPhone));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenUntrimmedPhoneValue_WhenCreatingPhone_ThenShouldHaveTrimmedPhoneValue()
    {
        // Arrange
        const string untrimmedPhoneValue = "  21998345677  ";
        const string expectedPhoneValue = "21998345677";

        // Act
        var phone = Phone.Create(untrimmedPhoneValue);

        // Assert
        Assert.Equal(expectedPhoneValue, phone.Value);
    }
}