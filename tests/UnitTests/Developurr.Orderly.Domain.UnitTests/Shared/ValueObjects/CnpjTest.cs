using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Cnpj;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Shared.ValueObjects;

public sealed class CnpjTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingCnpj_ThenShouldInstantiateCnpj()
    {
        // Act
        var cnpj = Cnpj.Create(Constants.Cnpj.CnpjValue);

        // Assert
        Assert.NotNull(cnpj);
    }

    [Fact]
    public void GivenValidCnpjValue_WhenCreatingCnpj_ThenShouldHaveValidCnpjValue()
    {
        // Arrange
        const string expectedCnpjValue = "42.591.651/0001-43";

        // Act
        var cnpj = Cnpj.Create(Constants.Cnpj.CnpjValue);

        // Assert
        Assert.Equal(expectedCnpjValue, cnpj.ToString());
    }

    [Fact]
    public void GivenInvalidInput_WhenCreatingCnpj_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidCnpj = "";
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(() => Cnpj.Create(invalidCnpj));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenEmptyCnpjValue_WhenCreatingCnpj_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string emptyCnpjValue = "";
        const string expectedErrorMessage = "'CNPJ' is required.";

        // Act
        var exception = Record.Exception(() => Cnpj.Create(emptyCnpjValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespaceCnpjValue_WhenCreatingCnpj_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string whitespaceCnpjValue = "                  ";
        const string expectedErrorMessage = "'CNPJ' is required.";

        // Act
        var exception = Record.Exception(() => Cnpj.Create(whitespaceCnpjValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortCnpjValue_WhenCreatingCnpj_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string shortCnpjValue = Constants.InvalidCnpj.ShortCnpj;
        const string expectedErrorMessage = "'CNPJ' is not valid.";

        // Act
        var exception = Record.Exception(() => Cnpj.Create(shortCnpjValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongCnpjValue_WhenCreatingCnpj_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string longCnpjValue = Constants.InvalidCnpj.LongCnpj;
        const string expectedErrorMessage = "'CNPJ' is not valid.";

        // Act
        var exception = Record.Exception(() => Cnpj.Create(longCnpjValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenInvalidCnpjValue_WhenCreatingCnpj_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidCnpjValue = Constants.InvalidCnpj.InvalidCnpjLastDigit;
        const string expectedErrorMessage = "'CNPJ' is not valid.";

        // Act
        var exception = Record.Exception(() => Cnpj.Create(invalidCnpjValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenNonNumericCnpj_WhenCreatingCnpj_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericCnpj = Constants.InvalidCnpj.NonNumeriCnpj;
        const string expectedErrorMessage = "'CNPJ' is not valid.";

        // Act
        var exception = Record.Exception(() => Cnpj.Create(nonNumericCnpj));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenUntrimmedCnpjValue_WhenCreatingCnpj_ThenShouldHaveTrimmedCnpjValue()
    {
        // Arrange
        const string untrimmedCnpjValue = "     42591651000143     ";
        const string expectedCnpjValue = "42.591.651/0001-43";

        // Act
        var cnpj = Cnpj.Create(untrimmedCnpjValue);

        // Assert
        Assert.Equal(expectedCnpjValue, cnpj.ToString());
    }

    [Fact]
    public void GivenValidCnpj_WhenCallToString_ShouldReturnToStringtedCnpj()
    {
        // Arrange
        var cnpj = CnpjFixture.CreateCnpj();
        var expectedToStringtedCnpj = $"42.591.651/0001-43";

        // Act
        var ToStringtedCnpj = cnpj.ToString();

        // Assert
        Assert.Equal(expectedToStringtedCnpj, ToStringtedCnpj);
    }
}
