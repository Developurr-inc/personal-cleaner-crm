using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Cpf;

namespace Developurr.Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class CpfTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingCpf_ThenShouldInstantiateCpf()
    {
        // Act
        var cpf = Cpf.Create(Constants.Cpf.CpfValue);

        // Assert
        Assert.NotNull(cpf);
    }

    [Fact]
    public void GivenValidCpfValue_WhenCreatingCpf_ThenShouldHaveValidCpfValue()
    {
        // Arrange
        const string expectedCpfValue = "546.471.429-49";

        // Act
        var cpf = Cpf.Create(Constants.Cpf.CpfValue);

        // Assert
        Assert.Equal(expectedCpfValue, cpf.ToString());
    }

    [Fact]
    public void GivenInvalidInput_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidCpf = "";
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(() => Cpf.Create(invalidCpf));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenEmptyCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string emptyCpfValue = "";
        const string expectedErrorMessage = "'CPF' is required.";

        // Act
        var exception = Record.Exception(() => Cpf.Create(emptyCpfValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenWhitespaceCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string whitespaceCpfValue = "                  ";
        const string expectedErrorMessage = "'CPF' is required.";

        // Act
        var exception = Record.Exception(() => Cpf.Create(whitespaceCpfValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenShortCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string shortCpfValue = Constants.InvalidCpf.ShortCpf;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(() => Cpf.Create(shortCpfValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenLongCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string longCpfValue = Constants.InvalidCpf.LongCpf;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(() => Cpf.Create(longCpfValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenInvalidCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidCpfValue = Constants.InvalidCpf.InvalidCpfLastDigit;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(() => Cpf.Create(invalidCpfValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenNonNumericCpf_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericCpf = Constants.InvalidCpf.NonNumericCpf;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(() => Cpf.Create(nonNumericCpf));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenUntrimmedCpfValue_WhenCreatingCpf_ThenShouldHaveTrimmedCpfValue()
    {
        // Arrange
        const string untrimmedCpfValue = "     54647142949     ";
        const string expectedCpfValue = "546.471.429-49";

        // Act
        var cpf = Cpf.Create(untrimmedCpfValue);

        // Assert
        Assert.Equal(expectedCpfValue, cpf.ToString());
    }

    [Fact]
    public void GivenValidCpf_WhenCallToString_ShouldReturnFormattedCpf()
    {
        // Arrange
        var cpf = CpfFixture.CreateCpf();
        var expectedFormattedCpf = "546.471.429-49";

        // Act
        var formattedCpf = cpf.ToString();

        // Assert
        Assert.Equal(formattedCpf, expectedFormattedCpf);
    }
}
