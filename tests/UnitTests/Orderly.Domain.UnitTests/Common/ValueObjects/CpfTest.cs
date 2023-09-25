using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Exceptions;
using Orderly.Domain.UnitTests.TestUtils.Constants;
using Orderly.Domain.UnitTests.TestUtils.Cpf;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class CpfTest
{
    [Theory]
    [InlineData(Constants.InvalidCpf.LongCpf)]
    [InlineData(Constants.InvalidCpf.ShortCpf)]
    [InlineData(Constants.InvalidCpf.InvalidCpfLastDigit)]
    public void GivenInvalidInput_WhenCreatingCpf_ThenShouldThrowEntityValidationException(
        string cpf
    )
    {
        // Act
        var exception = Record.Exception(
            () =>
                Cpf.Create(
                    cpf
                )
        );
        
        // Assert
        Assert.IsType<EntityValidationException>(exception);
    }

    [Fact]
    public void GivenValidCpfValue_WhenCreatingCpf_ThenShouldHaveValidCpfValue()
    {
        // Arrange
        const string expectedCpfValue = "546.471.429-49";

        // Act
        var cpf = Cpf.Create(Constants.Cpf.CpfValue);
        
        // Assert 
        Assert.Equal(expectedCpfValue, cpf.Value);
    }

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
}
