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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
            Constants.VendorId.Id,
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
                    Constants.VendorId.Id,
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
    public void GivenInvalidLastDigitCnpj_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string lastDigitCnpj = Constants.InvalidCnpj.InvalidCnpjLastDigit;
        const string expectedErrorMessage = "'CNPJ' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.VendorId.Id,
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
                    Constants.VendorId.Id,
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
    public void GivenInvalidAtBillingEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string atBillingEmail = Constants.InvalidEmail.InvalidAtEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.VendorId.Id,
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
                    Constants.VendorId.Id,
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
                    Constants.VendorId.Id,
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
    public void GivenInvalidAtNfeEmail_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string atNfeEmail = Constants.InvalidEmail.InvalidAtEmailAddress;
        const string expectedErrorMessage = "Invalid 'Email Address' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.VendorId.Id,
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
                    Constants.VendorId.Id,
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
                    Constants.VendorId.Id,
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
    public void GivenNonNumericLandline_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericLandline = Constants.InvalidPhone.NonNumericPhone;
        const string expectedErrorMessage = "'Phone Number' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.VendorId.Id,
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
    public void GivenNonNumericMobile_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericMobile = Constants.InvalidPhone.NonNumericPhone;
        const string expectedErrorMessage = "'Phone Number' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    Constants.VendorId.Id,
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
    
}
