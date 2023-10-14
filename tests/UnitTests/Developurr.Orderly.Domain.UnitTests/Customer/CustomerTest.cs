using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Customer;

public sealed class CustomerTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingCustomer_ThenShouldInstantiateCustomer()
    {
        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.NotNull(customer);
    }

    [Fact]
    public void GivenValidCnpj_WhenCreatingCustomer_ThenShouldHaveValidCnpj()
    {
        // Arrange
        const string cnpj = "59546515000134";
        const string expectedCnpj = "59.546.515/0001-34";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            cnpj,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedCnpj, customer.Cnpj.Format());
    }

    [Fact]
    public void GivenValidCorporateName_WhenCreatingCustomer_ThenShouldHaveValidCorporateName()
    {
        // Arrange
        const string expectedCorporateName = "Corporate Name";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            expectedCorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedCorporateName, customer.CorporateName);
    }

    [Fact]
    public void GivenValidTaxId_WhenCreatingCustomer_ThenShouldHaveValidTaxId()
    {
        // Arrange
        const string expectedTaxId = "12345";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            expectedTaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedTaxId, customer.TaxId);
    }

    [Fact]
    public void GivenValidTradeName_WhenCreatingCustomer_ThenShouldHaveValidTradeName()
    {
        // Arrange
        const string expectedTradeName = "Corporate Name";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            expectedTradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedTradeName, customer.TradeName);
    }

    [Fact]
    public void GivenValidSegment_WhenCreatingCustomer_ThenShouldHaveValidSegment()
    {
        // Arrange
        const string expectedSegment = "Corporate Name";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            expectedSegment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedSegment, customer.Segment);
    }
    
    [Fact]
    public void GivenValidBillingEmail_WhenCreatingCustomer_ThenShouldHaveValidBillingEmail()
    {
        // Arrange
        const string expectedBillingEmail = "email@email.com";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            expectedBillingEmail,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedBillingEmail, customer.BillingEmail?.Format());
    }
    
    [Fact]
    public void GivenValidNfeEmail_WhenCreatingCustomer_ThenShouldHaveValidNfeEmail()
    {
        // Arrange
        const string expectedNfeEmail = "email@email.com";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            expectedNfeEmail,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedNfeEmail, customer.NfeEmail.Format());
    }
    
    [Fact]
    public void GivenValidLandline_WhenCreatingCustomer_ThenShouldHaveValidLandline()
    {
        // Arrange
        const string expectedLandline = "21998345677";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            expectedLandline,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedLandline, customer.Landline?.Value);
    }
    
    [Fact]
    public void GivenValidMobile_WhenCreatingCustomer_ThenShouldHaveValidMobile()
    {
        // Arrange
        const string expectedMobile = "21998345677";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            expectedMobile,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedMobile, customer.Mobile?.Value);
    }
    
    [Fact]
    public void GivenValidObservation_WhenCreatingCustomer_ThenShouldHaveValidObservation()
    {
        // Arrange
        const string expectedObservation = "Observation";

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            expectedObservation
        );

        // Assert
        Assert.Equal(expectedObservation, customer.Observation);
    }
    
    [Theory]
    
    [InlineData("", "Corporate Name", "12345", "Trade Name", "Segment", "email@email.com", "email@email.com", "2422546870", "24954365490", "Observacao")]
    [InlineData("59.546.515/0001-34", "", "12345", "Trade Name", "Segment", "email@email.com", "email@email.com", "2422546870", "24954365490", "Observacao")]
    [InlineData("59.546.515/0001-34", "Corporate Name", "", "Trade Name", "Segment", "email@email.com", "email@email.com", "2422546870", "24954365490", "Observacao")]
    [InlineData( "59.546.515/0001-34", "Corporate Name", "12345", "", "Segment", "email@email.com", "email@email.com", "2422546870", "24954365490", "Observacao")]
    [InlineData( "59.546.515/0001-34", "Corporate Name", "12345", "Trade Name", "", "email@email.com", "email@email.com", "2422546870", "24954365490", "Observacao")]
    [InlineData("59.546.515/0001-34", "Corporate Name", "12345", "Trade Name", "Segment", "", "email@email.com", "2422546870", "24954365490", "Observacao")]
    [InlineData("59.546.515/0001-34", "Corporate Name", "12345", "Trade Name", "Segment", "email@email.com", "", "2422546870", "24954365490", "Observacao")]
    [InlineData("59.546.515/0001-34", "Corporate Name", "12345", "Trade Name", "Segment", "email@email.com", "email@email.com", "", "24954365490", "Observacao")]
    [InlineData("59.546.515/0001-34", "Corporate Name", "12345", "Trade Name", "Segment", "email@email.com", "email@email.com", "2422546870", "", "Observacao")]
    [InlineData( "59.546.515/0001-34", "Corporate Name", "12345", "Trade Name", "Segment", "email@email.com", "email@email.com", "2422546870", "24954365490", "")]
    
    public void GivenInvalidInput_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage(
        string cnpjValue,
        string corporateName,
        string taxId,
        string tradeName,
        string segment,
        string billingEmail,
        string nfeEmail,
        string landline,
        string mobile,
        string observation
    )
    {
        // Arrange
        const string expectedErrorMessage = "There are validation errors.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    cnpjValue,
                    corporateName,
                    taxId,
                    tradeName,
                    segment,
                    billingEmail,
                    nfeEmail,
                    landline,
                    mobile,
                    observation
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Fact]
    public void GivenEmptyCnpj_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyCnpj = "";
        const string expectedErrorMessage = "'CNPJ' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    emptyCnpj,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceCnpj_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceCnpj = "       ";
        const string expectedErrorMessage = "'CNPJ' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    whiteSpaceCnpj,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortCnpj_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortCnpj = Constants.InvalidCnpj.ShortCnpj;
        const string expectedErrorMessage = "'CNPJ' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    shortCnpj,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongCnpj_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longCnpj = Constants.InvalidCnpj.LongCnpj;
        const string expectedErrorMessage = "'CNPJ' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    longCnpj,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidLastDigitCnpj_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string lastDigitCnpj = Constants.InvalidCnpj.InvalidCnpjLastDigit;
        const string expectedErrorMessage = "'CNPJ' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    lastDigitCnpj,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenNonNumericCnpj_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericCnpj = Constants.InvalidCnpj.NonNumeriCnpj;
        const string expectedErrorMessage = "'CNPJ' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    nonNumericCnpj,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyCorporateName_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyCorporateName = "";
        const string expectedErrorMessage = "'Corporate Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    emptyCorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceCorporateName_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceCorporateName = "       ";
        const string expectedErrorMessage = "'Corporate Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    whiteSpaceCorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortCorporateName_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortCorporateName = Constants.InvalidCustomer.ShortCorporateName;
        const string expectedErrorMessage = "'Corporate Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    shortCorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongCorporateName_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longCorporateName = Constants.InvalidCustomer.LongCorporateName;
        const string expectedErrorMessage = "'Corporate Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    longCorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyTaxId_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyTaxId = "";
        const string expectedErrorMessage = "'Tax ID' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    emptyTaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceTaxId_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceTaxId = "       ";
        const string expectedErrorMessage = "'Tax ID' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    whiteSpaceTaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortTaxId_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortTaxId = Constants.InvalidCustomer.ShortTaxId;
        const string expectedErrorMessage = "'Tax ID' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    shortTaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongTaxId_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longTaxId = Constants.InvalidCustomer.LongTaxId;
        const string expectedErrorMessage = "'Tax ID' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    longTaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyTradeName_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyTradeName = "";
        const string expectedErrorMessage = "'Trade Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    emptyTradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceTradeName_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceTradeName = "       ";
        const string expectedErrorMessage = "'Trade Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    whiteSpaceTradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortTradeName_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortTradeName = Constants.InvalidCustomer.ShortTradeName;
        const string expectedErrorMessage = "'Trade Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    shortTradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongTradeName_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longTradeName = Constants.InvalidCustomer.LongTradeName;
        const string expectedErrorMessage = "'Trade Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    longTradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptySegment_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptySegment = "";
        const string expectedErrorMessage = "'Segment' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    emptySegment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceSegment_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceSegment = "       ";
        const string expectedErrorMessage = "'Segment' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    whiteSpaceSegment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortSegment_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortSegment = Constants.InvalidCustomer.ShortSegment;
        const string expectedErrorMessage = "'Segment' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    shortSegment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongSegment_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longSegment = Constants.InvalidCustomer.LongSegment;
        const string expectedErrorMessage = "'Segment' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    longSegment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyBillingEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyBillingEmail = "";
        const string expectedErrorMessage = "'Email Address' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    emptyBillingEmail,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceBillingEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceBillingEmail = "       ";
        const string expectedErrorMessage = "'Email Address' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    whiteSpaceBillingEmail,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortBillingEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortBillingEmail = Constants.InvalidEmail.ShortEmailAddress;
        const string expectedErrorMessage = "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    shortBillingEmail,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongBillingEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longBillingEmail = Constants.InvalidEmail.LongEmailAddress;
        const string expectedErrorMessage = "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    longBillingEmail,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidAtBillingEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string atBillingEmail = Constants.InvalidEmail.InvalidAtEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    atBillingEmail,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidDotBillingEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string dotBillingEmail = Constants.InvalidEmail.InvalidDotEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    dotBillingEmail,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidAtAndDotBillingEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string atAndDotBillingEmail = Constants.InvalidEmail.InvalidAtAndDotEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    atAndDotBillingEmail,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyNfeEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyNfeEmail = "";
        const string expectedErrorMessage = "'Email Address' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    emptyNfeEmail,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceNfeEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceNfeEmail = "       ";
        const string expectedErrorMessage = "'Email Address' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    whiteSpaceNfeEmail,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortNfeEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortNfeEmail = Constants.InvalidEmail.ShortEmailAddress;
        const string expectedErrorMessage = "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    shortNfeEmail,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongNfeEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longNfeEmail = Constants.InvalidEmail.LongEmailAddress;
        const string expectedErrorMessage = "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    longNfeEmail,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidAtNfeEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string atNfeEmail = Constants.InvalidEmail.InvalidAtEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    atNfeEmail,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidDotNfeEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string dotNfeEmail = Constants.InvalidEmail.InvalidDotEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    dotNfeEmail,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidAtAndDotNfeEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string atAndDotNfeEmail = Constants.InvalidEmail.InvalidAtAndDotEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    atAndDotNfeEmail,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyLandline_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyLandline = "";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    emptyLandline,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceLandline_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceLandline = "       ";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    whiteSpaceLandline,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortLandline_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortLandline = Constants.InvalidPhone.ShortPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    shortLandline,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongLandline_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longLandline = Constants.InvalidPhone.LongPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    longLandline,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenNonNumericLandline_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericLandline = Constants.InvalidPhone.NonNumericPhone;
        const string expectedErrorMessage = "'Phone Number' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    nonNumericLandline,
                    Constants.Phone.PhoneValue,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyMobile_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyMobile = "";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    emptyMobile,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceMobile_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whiteSpaceMobile = "       ";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    whiteSpaceMobile,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortMobile_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortMobile = Constants.InvalidPhone.ShortPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    shortMobile,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongMobile_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longMobile = Constants.InvalidPhone.LongPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    longMobile,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenNonNumericMobile_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericMobile = Constants.InvalidPhone.NonNumericPhone;
        const string expectedErrorMessage = "'Phone Number' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    nonNumericMobile,
                    Constants.Customer.Observation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhiteSpaceObservation_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const string whiteSpaceObservation = "       ";
        const string expectedObservation = "";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            whiteSpaceObservation
        );

        // Assert
        Assert.Equal(expectedObservation, salesConsultant.Observation);
    }
    
    [Fact]
    public void GivenLongObservation_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longObservation = Constants.InvalidCustomer.LongObservation;
        const string expectedErrorMessage = "'Observation' should be between 0 and 10000 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.SalesConsultantId.Id,
                    Constants.Cnpj.CnpjValue,
                    Constants.Customer.CorporateName,
                    Constants.Customer.TaxId,
                    Constants.Customer.TradeName,
                    Constants.Customer.Segment,
                    Constants.Email.EmailValue,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue,
                    longObservation
                )
        );
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenUntrimmedCnpj_WhenCreatingCustomer_ThenShouldHaveTrimmedCnpj()
    {
        // Arrange
        const string untrimmedCnpj = "    59546515000134       ";
        const string expectedCnpj = "59.546.515/0001-34";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            untrimmedCnpj,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedCnpj, salesConsultant.Cnpj.Format());
    }
    
    [Fact]
    public void GivenUntrimmedCorporateName_WhenCreatingCustomer_ThenShouldHaveTrimmedCorporateName()
    {
        // Arrange
        const string untrimmedCorporateName = "    Corporate Name       ";
        const string expectedCorporateName = "Corporate Name";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            untrimmedCorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedCorporateName, salesConsultant.CorporateName);
    }
    
    [Fact]
    public void GivenUntrimmedTaxId_WhenCreatingCustomer_ThenShouldHaveTrimmedTaxId()
    {
        // Arrange
        const string untrimmedTaxId = "    12345       ";
        const string expectedTaxId = "12345";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            untrimmedTaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedTaxId, salesConsultant.TaxId);
    }
    
    [Fact]
    public void GivenUntrimmedTradeName_WhenCreatingCustomer_ThenShouldHaveTrimmedTradeName()
    {
        // Arrange
        const string untrimmedTradeName = "    Trade Name       ";
        const string expectedTradeName = "Trade Name";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            untrimmedTradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedTradeName, salesConsultant.TradeName);
    }
    
    [Fact]
    public void GivenUntrimmedSegment_WhenCreatingCustomer_ThenShouldHaveTrimmedSegment()
    {
        // Arrange
        const string untrimmedSegment = "    Segment       ";
        const string expectedSegment = "Segment";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            untrimmedSegment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedSegment, salesConsultant.Segment);
    }
    
    [Fact]
    public void GivenUntrimmedBillingEmail_WhenCreatingCustomer_ThenShouldHaveTrimmedBillingEmail()
    {
        // Arrange
        const string untrimmedBillingEmail = "    email@email.com       ";
        const string expectedBillingEmail = "email@email.com";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            untrimmedBillingEmail,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedBillingEmail, salesConsultant.BillingEmail?.Format());
    }
    
    [Fact]
    public void GivenUntrimmedNfeEmail_WhenCreatingCustomer_ThenShouldHaveTrimmedNfeEmail()
    {
        // Arrange
        const string untrimmedNfeEmail = "    email@email.com       ";
        const string expectedNfeEmail = "email@email.com";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            untrimmedNfeEmail,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedNfeEmail, salesConsultant.NfeEmail.Format());
    }
    
    [Fact]
    public void GivenUntrimmedLandline_WhenCreatingCustomer_ThenShouldHaveTrimmedLandline()
    {
        // Arrange
        const string untrimmedLandline = "    21998345677       ";
        const string expectedLandline = "21998345677";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            untrimmedLandline,
            Constants.Phone.PhoneValue,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedLandline, salesConsultant.Landline?.Value);
    }
    
    [Fact]
    public void GivenUntrimmedMobile_WhenCreatingCustomer_ThenShouldHaveTrimmedMobile()
    {
        // Arrange
        const string untrimmedMobile = "    21998345677       ";
        const string expectedMobile = "21998345677";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            untrimmedMobile,
            Constants.Customer.Observation
        );

        // Assert
        Assert.Equal(expectedMobile, salesConsultant.Mobile?.Value);
    }
    
    [Fact]
    public void GivenUntrimmedObservation_WhenCreatingCustomer_ThenShouldHaveTrimmedObservation()
    {
        // Arrange
        const string untrimmedObservation = "    Observation       ";
        const string expectedObservation = "Observation";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.Customer.Customer.Create(
            Constants.SalesConsultantId.Id,
            Constants.Cnpj.CnpjValue,
            Constants.Customer.CorporateName,
            Constants.Customer.TaxId,
            Constants.Customer.TradeName,
            Constants.Customer.Segment,
            Constants.Email.EmailValue,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue,
            untrimmedObservation
        );

        // Assert
        Assert.Equal(expectedObservation, salesConsultant.Observation);
    }
    
}
