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
        var nonEmptyText = Domain.Shared.ValueObjects.NonEmptyText.Create(value.ToString());

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
            expectedText.ToString()
        );

        // Assert
        Assert.Equal(expectedText, text);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenInvalidInput_WhenCreatingNonEmptyText_ThenShouldThrowEntityValidationExceptionWithMessage(
        string invalidText
    )
    {
        // Assert
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(
            () => Domain.Shared.ValueObjects.NonEmptyText.Create(invalidText)
        );
        // Assert
        var domainValidationException = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedErrorMessage, domainValidationException.Message);
    }

    [Fact]
    public void GivenLongText_WhenCreatingNonEmptyText_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        var longText = NonEmptyTextFixture.CreateInvalidLongNonEmptyText();
        // const string expectedErrorMessage = "Value cannot be longer than 255 characters.";

        // Act
        var exception = Record.Exception(
            () => Domain.Shared.ValueObjects.NonEmptyText.Create(longText)
        );
        // Assert
        var domainValidationException = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, domainValidationException.Message);
    }
}
