using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Exceptions;
using Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class CnpjTest
{
    [Theory]
    [InlineData(Constants.InvalidCnpj.LongCnpj)]
    [InlineData(Constants.InvalidCnpj.ShortCnpj)]
    [InlineData(Constants.InvalidCnpj.InvalidCnpjLastDigit)]
    public void GivenInvalidInput_WhenCreatingCnpj_ThenShouldThrowEntityValidationException(
        string cnpj
    )
    {
        // Act
        var exception = Record.Exception(
            () =>
                Cnpj.Create(
                    cnpj
                )
        );
        
        // Assert
        Assert.IsType<EntityValidationException>(exception);
    }

    [Fact]
    public void GivenValidCnpjValue_WhenCreatingCnpj_ThenShouldHaveValidCnpjValue()
    {
        // Arrange
        const string expectedCnpjValue = "42.591.651/0001-43";

        // Act
        var cnpj = Cnpj.Create(Constants.Cnpj.CnpjValue);
        
        // Assert 
        Assert.Equal(expectedCnpjValue, cnpj.Value);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingCnpj_ThenShouldInstantiateCnpj()
    {
        // Act
        var cnpj = Cnpj.Create(
            Constants.Cnpj.CnpjValue
        );

        // Assert
        Assert.NotNull(cnpj);
    }
}
