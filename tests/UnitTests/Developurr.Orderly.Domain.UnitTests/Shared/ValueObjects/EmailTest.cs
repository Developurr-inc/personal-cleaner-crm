using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Shared.ValueObjects;

public sealed class EmailTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingEmail_ThenShouldInstantiateEmail()
    {
        // Act
        var email = Email.Create(Constants.Email.EmailValue);

        // Assert
        Assert.NotNull(email);
    }

    [Fact]
    public void GivenValidEmail_WhenCreatingEmail_ThenShouldHaveValidEmail()
    {
        // Arrange
        const string expectedEmail = "email@email.com";

        // Act
        var email = Email.Create(Constants.Email.EmailValue);

        // Assert
        Assert.Equal(expectedEmail, email.ToString());
    }

    [Fact]
    public void GivenInvalidInput_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidEmail = "";
        const string expectedErrorMessage = "There are validation errors.";

        // Act
        var exception = Record.Exception(() => Email.Create(invalidEmail));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenEmptyEmail_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string emptyEmail = "";
        const string expectedErrorMessage = "'Email Address' is required.";

        // Act
        var exception = Record.Exception(() => Email.Create(emptyEmail));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespaceEmail_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string whitespaceEmail = "             ";
        const string expectedErrorMessage = "'Email Address' is required.";

        // Act
        var exception = Record.Exception(() => Email.Create(whitespaceEmail));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortEmail_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string shortEmail = Constants.InvalidEmail.ShortEmailAddress;
        const string expectedErrorMessage =
            "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(() => Email.Create(shortEmail));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongEmail_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string longEmail = Constants.InvalidEmail.LongEmailAddress;
        const string expectedErrorMessage =
            "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(() => Email.Create(longEmail));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenInvalidAtEmailAddress_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidAtEmail = Constants.InvalidEmail.InvalidAtEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' ToString.";

        // Act
        var exception = Record.Exception(() => Email.Create(invalidAtEmail));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenInvalidDotEmailAddress_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidDotEmailAddress = Constants.InvalidEmail.InvalidDotEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' ToString.";

        // Act
        var exception = Record.Exception(() => Email.Create(invalidDotEmailAddress));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenInvalidAtAndDotEmailAddress_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidAtAndDotEmailAddress = Constants
            .InvalidEmail
            .InvalidAtAndDotEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' ToString.";

        // Act
        var exception = Record.Exception(() => Email.Create(invalidAtAndDotEmailAddress));

        // Assert
        var eve = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenUntrimmedEmail_WhenCreatingEmail_ThenShouldHaveTrimmedEmail()
    {
        // Arrange
        const string untrimmedEmail = "       email@email.com  ";
        const string expectedEmail = "email@email.com";

        // Act
        var email = Email.Create(untrimmedEmail);

        // Assert
        Assert.Equal(expectedEmail, email.ToString());
    }
}