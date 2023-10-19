using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Shipping;

public sealed class ShippingTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingShipping_ThenShouldInstantiateShipping()
    {
        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.NotNull(shipping);
    }

    [Fact]
    public void GivenValidCnpj_WhenCreatingShipping_ThenShouldHaveValidCnpj()
    {
        // Arrange
        const string cnpj = "59546515000134";
        const string expectedCnpj = "59.546.515/0001-34";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            cnpj,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedCnpj, shipping.Cnpj.ToString());
    }

    [Fact]
    public void GivenValidCorporateName_WhenCreatingShipping_ThenShouldHaveValidCorporateName()
    {
        // Arrange
        const string expectedCorporateName = "Sacolas MJ";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            expectedCorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedCorporateName, shipping.CorporateName);
    }

    [Fact]
    public void GivenValidTaxId_WhenCreatingShipping_ThenShouldHaveValidTaxId()
    {
        // Arrange
        const string expectedTaxId = "123456";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            expectedTaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedTaxId, shipping.TaxId);
    }

    [Fact]
    public void GivenValidTradeName_WhenCreatingShipping_ThenShouldHaveValidTradeName()
    {
        // Arrange
        const string expectedTradeName = "Sacolas MJ";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            expectedTradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedTradeName, shipping.TradeName);
    }

    [Fact]
    public void GivenValidSegment_WhenCreatingShipping_ThenShouldHaveValidSegment()
    {
        // Arrange
        const string expectedSegment = "Embalagens";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            expectedSegment
        );

        // Assert
        Assert.Equal(expectedSegment, shipping.Segment);
    }

    [Theory]
    [InlineData("", "Sacolas MJ", "123456", "Sacolas MJ", "Embalagens")]
    [InlineData("12.345.678/0001-00", "", "123456", "Sacolas MJ", "Embalagens")]
    [InlineData("12.345.678/0001-00", "Sacolas MJ", "", "Sacolas MJ", "Embalagens")]
    [InlineData("12.345.678/0001-00", "Sacolas MJ", "123456", "", "Embalagens")]
    [InlineData("12.345.678/0001-00", "Sacolas MJ", "123456", "Sacolas MJ", "")]
    public void GivenInvalidInput_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage(
        string cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment
    )
    {
        // Arrange
        const string expectedErrorMessage = "There are validation errors.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    cnpj,
                    corporateName,
                    taxId,
                    tradeName,
                    segment
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenEmptyCnpj_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyCnpj = "";
        const string expectedErrorMessage = "'CNPJ' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    emptyCnpj,
                    Constants.Shipping.CorporateName,
                    Constants.Shipping.TaxId,
                    Constants.Shipping.TradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }

    [Fact]
    public void GivenWhitespaceCnpj_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceCnpj = "             ";
        const string expectedErrorMessage = "'CNPJ' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    whitespaceCnpj,
                    Constants.Shipping.CorporateName,
                    Constants.Shipping.TaxId,
                    Constants.Shipping.TradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }

    [Fact]
    public void GivenEmptyCorporateName_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyCorporateName = "";
        const string expectedErrorMessage = "'Corporate Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    emptyCorporateName,
                    Constants.Shipping.TaxId,
                    Constants.Shipping.TradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenWhitespaceCorporateName_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceCorporateName = "             ";
        const string expectedErrorMessage = "'Corporate Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    whitespaceCorporateName,
                    Constants.Shipping.TaxId,
                    Constants.Shipping.TradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenLongCorporateName_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longCorporateName = Constants.InvalidShipping.LongCorporateName;
        const string expectedErrorMessage = "'Corporate Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    longCorporateName,
                    Constants.Shipping.TaxId,
                    Constants.Shipping.TradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenEmptyTaxId_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyTaxId = "";
        const string expectedErrorMessage = "'Tax ID' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    Constants.Shipping.CorporateName,
                    emptyTaxId,
                    Constants.Shipping.TradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenWhitespaceTaxId_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceTaxId = "             ";
        const string expectedErrorMessage = "'Tax ID' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    Constants.Shipping.CorporateName,
                    whitespaceTaxId,
                    Constants.Shipping.TradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenLongTaxId_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longTaxId = Constants.InvalidShipping.LongTaxId;
        const string expectedErrorMessage = "'Tax ID' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    Constants.Shipping.CorporateName,
                    longTaxId,
                    Constants.Shipping.TradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenEmptyTradeName_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyTradeName = "";
        const string expectedErrorMessage = "'Trade Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    Constants.Shipping.CorporateName,
                    Constants.Shipping.TaxId,
                    emptyTradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenWhitespaceTradeteName_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceTradeName = "             ";
        const string expectedErrorMessage = "'Trade Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    Constants.Shipping.CorporateName,
                    Constants.Shipping.TaxId,
                    whitespaceTradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenLongTradeName_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longTradeName = Constants.InvalidShipping.LongTradeName;
        const string expectedErrorMessage = "'Trade Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    Constants.Shipping.CorporateName,
                    Constants.Shipping.TaxId,
                    longTradeName,
                    Constants.Shipping.Segment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenEmptySegment_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptySegment = "";
        const string expectedErrorMessage = "'Segment' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    Constants.Shipping.CorporateName,
                    Constants.Shipping.TaxId,
                    Constants.Shipping.TradeName,
                    emptySegment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenWhitespaceSegment_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceTradeName = "             ";
        const string expectedErrorMessage = "'Segment' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    Constants.Shipping.CorporateName,
                    Constants.Shipping.TaxId,
                    Constants.Shipping.TradeName,
                    whitespaceTradeName
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenLongSegment_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longSegment = Constants.InvalidShipping.LongSegment;
        const string expectedErrorMessage = "'Segment' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    Constants.Cnpj.CnpjValue,
                    Constants.Shipping.CorporateName,
                    Constants.Shipping.TaxId,
                    Constants.Shipping.TradeName,
                    longSegment
                )
        );

        // Assert
        var eve = Assert.IsType<System.ArgumentException>(exception);
        //Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    
    
    [Fact]
    public void GivenUntrimmedCnpj_WhenCreatingShipping_ThenShouldHaveTrimmedCnpj()
    {
        // Arrange
        const string untrimmedCnpj = "    59.546.515/0001-34       ";
        const string expectedCnpj = "59.546.515/0001-34";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            untrimmedCnpj,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedCnpj, shipping.Cnpj.Format());
    }

    [Fact]
    public void GivenUntrimmedCorporateName_WhenCreatingShipping_ThenShouldHaveTrimmedCorporateName()
    {
        // Arrange
        const string untrimmedCorporateName = "     Sacolas MJ      ";
        const string expectedCorporateName = "Sacolas MJ";

        // Act
        var corporateName = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            untrimmedCorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedCorporateName, corporateName.CorporateName);
    }

    [Fact]
    public void GivenUntrimmedTaxId_WhenCreatingShipping_ThenShouldHaveTrimmedTaxId()
    {
        // Arrange
        const string untrimmedTaxId = " 123456 ";
        const string expectedTaxId = "123456";

        // Act
        var taxId = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            untrimmedTaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedTaxId, taxId.TaxId);
    }

    [Fact]
    public void GivenUntrimmedTradeName_WhenCreatingShipping_ThenShouldHaveTrimmedTradeName()
    {
        // Arrange
        const string untrimmedTradeName = "    Barra da Tijuca     ";
        const string expectedTradeName = "Barra da Tijuca";

        // Act
        var tradeName = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            untrimmedTradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedTradeName, tradeName.TradeName);
    }

    [Fact]
    public void GivenUntrimmedSegment_WhenCreatingAddress_ThenShouldHaveTrimmedSegment()
    {
        // Arrange
        const string untrimmedSegment = "   São Paulo       ";
        const string expectedSegment = "São Paulo";

        // Act
        var segment = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            untrimmedSegment
        );

        // Assert
        Assert.Equal(expectedSegment, segment.Segment);
    }
}
