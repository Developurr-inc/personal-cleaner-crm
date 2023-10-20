using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;

namespace Developurr.Orderly.Domain.UnitTests.Shared.ValueObjects;

public sealed class NonEmptyTextTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingNonEmptyText_ThenShouldInstantiateNonEmptyText()
    {
        // Arrange
        var value = NonEmptyTextFixture.CreateNonEmptyText();
    
        // Act
        var nonEmptyText = Domain.Shared.ValueObjects.NonEmptyText.Create(
            value.Value
            );

        // Assert
        Assert.NotNull(nonEmptyText);
    }
    
    [Fact]
    public void GivenValidText_WhenCreatingNonEmptyText_ThenShouldHaveValidText()
    {
        // Arrange
        var expectedText = NonEmptyTextFixture.CreateNonEmptyText();
        
        // Act
        var text = Developurr.Orderly.Domain.Shared.ValueObjects.NonEmptyText.Create(
            expectedText.Value
        );

        // Assert
        Assert.Equal(expectedText.Value, text.Value);
    }

    [Fact]
    public void GivenEmptyText_WhenCreatingNonEmptyText_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyText = "";
        const string expectedErrorMessage = "Value cannot be null or whitespace.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shared.ValueObjects.NonEmptyText.Create(
                    emptyText
                )
        );
        // Assert
        var eve = Assert.IsType<ArgumentException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenWhiteSpaceText_WhenCreatingNonEmptyText_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceText = "       ";
        const string expectedErrorMessage = "Value cannot be null or whitespace.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shared.ValueObjects.NonEmptyText.Create(
                    whiteSpaceText
                )
        );
        // Assert
        var eve = Assert.IsType<ArgumentException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenLongText_WhenCreatingNonEmptyText_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longText = 
            "a6HAMB29ELx6yJP87NrSfIZGqkQFcrE9tZqUoS6Qnfj8rPvpQgMz0UyRk24KOVYF7zvuTmQc80hcjiWgNqUgiRQ0RDKhTQf9f9elRSePSJI13SGwfsWuoN7Ne6iv7O7IX57wRP6UGLE1rmaM99y9Vs1dSphNDHhlwqJHaIciQxbjBriPYoJ32D9u3w4nAULJHZCpCvcTyiSHtadd26nBmI0RzxRQB4EcnuNP46wHPRtLr4NXcW1f1OlBMUkc5GV2";
        const string expectedErrorMessage = "Value cannot be longer than 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shared.ValueObjects.NonEmptyText.Create(
                    longText
                )
        );
        // Assert
        var eve = Assert.IsType<ArgumentException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }
}
