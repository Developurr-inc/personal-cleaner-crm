using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Exceptions;
using Orderly.Domain.UnitTests.TestUtils.Address;
using Orderly.Domain.UnitTests.TestUtils.Constants;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

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
    
    
    [Theory]
    [InlineData("")]
    public void GivenInvalidInput_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage(
        string email
    )
    {
        // Arrange
        const string expectedErrorMessage = "There are validation errors.";

        // Act
        var exception = Record.Exception(
            () =>
                Email.Create(
                    email
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    
    
    [Fact]
    public void GivenEmptyEmail_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string emptyEmail = "";
        const string expectedErrorMessage = "'Email Address' is required.";
        // const string expectedErrorMessage = "'Email' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Email.Create(
                    emptyEmail
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    
    [Fact]
    public void GivenWhitespaceEmail_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string whitespaceEmail = "             ";
        const string expectedErrorMessage = "'Email Address' is required.";
        // const string expectedErrorMessage = "'Email' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Email.Create(
                    whitespaceEmail
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    
    
    [Fact]
    public void GivenShortEmail_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string shortEmail = Constants.InvalidEmail.ShortEmailAddress;
        const string expectedErrorMessage = "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Email.Create(
                    shortEmail
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongEmail_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string longEmail = Constants.InvalidEmail.LongEmailAddress;
        const string expectedErrorMessage = "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Email.Create(
                    longEmail
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidAtEmailAddress_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidAtEmail = Constants.InvalidEmail.InvalidAtEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";
        // const string expectedErrorMessage = "'Email' should have @.";

        // Act
        var exception = Record.Exception(
            () =>
                Email.Create(
                    invalidAtEmail
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidDotEmailAddress_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidDotEmailAddress = Constants.InvalidEmail.InvalidDotEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";
        // const string expectedErrorMessage = "'Email' should have dot.";

        // Act
        var exception = Record.Exception(
            () =>
                Email.Create(
                    invalidDotEmailAddress
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidAtAndDotEmailAddress_WhenCreatingEmail_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidAtAndDotEmailAddress = Constants.InvalidEmail.InvalidAtAndDotEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";
        // const string expectedErrorMessage = "'Email' should have @ and dot.";
    
        // Act
        var exception = Record.Exception(
            () =>
                Email.Create(
                    invalidAtAndDotEmailAddress
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    
}
