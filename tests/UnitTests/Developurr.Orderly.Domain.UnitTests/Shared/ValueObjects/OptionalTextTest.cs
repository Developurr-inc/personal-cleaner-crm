using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;

namespace Developurr.Orderly.Domain.UnitTests.Shared.ValueObjects;

public sealed class OptionalTextTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingOptionalText_ThenShouldInstantiateOptionalText()
    {
        // Arrange
        var value = OptionalTextFixture.CreateOptionalText();

        // Act
        var optionalText = Domain.Shared.ValueObjects.OptionalText.Create(value.ToString());

        // Assert
        Assert.NotNull(optionalText);
    }

    [Fact]
    public void GivenInvalidInput_WhenCreatingNonEmptyText_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(
            () => Domain.Shared.ValueObjects.NonEmptyText.Create(null!)
        );
        // Assert
        var domainValidationException = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedErrorMessage, domainValidationException.Message);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData(" ", "")]
    [InlineData(" Optional Text  ", "Optional Text")]
    public void GivenValidText_WhenCreatingOptionalText_ThenShouldHaveValidText(
        string text,
        string expectedText
    )
    {
        // Act
        var optionalText = Domain.Shared.ValueObjects.OptionalText.Create(text);

        // Assert
        Assert.Equal(expectedText, optionalText.ToString());
    }

    [Fact]
    public void GivenLongText_WhenCreatingOptionalText_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var longText = OptionalTextFixture.CreateInvalidOptionalText();
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(
            () => Domain.Shared.ValueObjects.OptionalText.Create(longText)
        );

        // Assert
        var domainValidationException = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedErrorMessage, domainValidationException.Message);
    }
}