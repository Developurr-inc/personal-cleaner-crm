using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Exceptions;
using Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class CpfTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingCpf_ThenShouldInstantiateCpf()
    {
        // Act
        var cpf = Cpf.Create(
            Constants.Cpf.CpfValue
        );

        // Assert
        Assert.NotNull(cpf);
    }
    
    [Fact]
    public void GivenValidCpfValue_WhenCreatingCpf_ThenShouldHaveValidCpfValue()
    {
        // Arrange
        const string expectedCpfValue = "54647142949";

        // Act
        var cpf = Cpf.Create(Constants.Cpf.CpfValue);
        
        // Assert 
        Assert.Equal(expectedCpfValue, cpf.Value);
    }
    
    
    [Theory]
    [InlineData("")]
    public void GivenInvalidInput_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage(
        string cpf
    )
    {
        // Arrange
        const string expectedErrorMessage = "There are validation errors.";
        
        // Act
        var exception = Record.Exception(
            () =>
                Cpf.Create(
                    cpf
                )
        );
        
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenEmptyCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string emptyCpfValue = "";
        const string expectedErrorMessage = "'CPF' is required.";
        
        // Act
        var exception = Record.Exception(
            () =>
                Cpf.Create(
                    emptyCpfValue
                )
        );
        
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }

    [Fact]
    public void GivenWhitespaceCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string whitespaceCpfValue = "                  ";
        const string expectedErrorMessage = "'CPF' is required.";
        
        // Act
        var exception = Record.Exception(
            () =>
                Cpf.Create(
                    whitespaceCpfValue
                )
        );
        
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }

    [Fact]
    public void GivenShortCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string shortCpfValue = Constants.InvalidCpf.ShortCpf;
        const string expectedErrorMessage = "'CPF' is not valid."; //'Cpf' should be 11 characters.
        
        // Act
        var exception = Record.Exception(
            () =>
                Cpf.Create(
                    shortCpfValue
                )
        );
        
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string longCpfValue = Constants.InvalidCpf.LongCpf;
        const string expectedErrorMessage = "'CPF' is not valid.";//Cpf' should be 11 characters.
        
        // Act
        var exception = Record.Exception(
            () =>
                Cpf.Create(
                    longCpfValue
                )
        );
        
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }

    [Fact]
    public void GivenInvalidCpfValue_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string invalidCpfValue = Constants.InvalidCpf.InvalidCpfLastDigit;
        const string expectedErrorMessage = "'CPF' is not valid."; //'Cpf' is invalid.
        
        // Act
        var exception = Record.Exception(
            () =>
                Cpf.Create(
                    invalidCpfValue
                )
        );
        
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenNonNumericCpf_WhenCreatingCpf_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericCpf = Constants.InvalidCpf.NonNumeriCpf;
        const string expectedErrorMessage = "'CPF' is not valid."; //Invalid 'Cpf' format.

        // Act
        var exception = Record.Exception(
            () =>
                Cpf.Create(
                    nonNumericCpf
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }

    [Fact]
    public void GivenUntrimmedCpfValue_WhenCreatingCpf_ThenShouldHaveTrimmedCpfValue()
    {
        // Arrange
        const string untrimmedCpfValue = "     54647142949     ";
        const string expectedCpfValue = "54647142949";
        
        // Act
        var cpf = Cpf.Create(untrimmedCpfValue);
        
        // Assert
        Assert.Equal(expectedCpfValue, cpf.Value);
    }
    
}
