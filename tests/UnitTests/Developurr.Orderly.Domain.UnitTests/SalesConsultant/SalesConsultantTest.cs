using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.SalesConsultant;

public sealed class SalesConsultantTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingSalesConsultant_ThenShouldInstantiateSalesConsultant()
    {
        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.NotNull(salesConsultant);
    }
    
    [Fact]
    public void GivenValidCpf_WhenCreatingSalesConsultant_ThenShouldHaveValidCpf()
    {
        // Arrange
        const string cpf = "54647142949";
        const string expectedCpf = "546.471.429-49";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            cpf,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedCpf, salesConsultant.Cpf.Format());
    }
    
    [Fact]
    public void GivenValidStreet_WhenCreatingSalesConsultant_ThenShouldHaveValidStreet()
    {
        // Arrange
        const string expectedStreet = "Rua john";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            expectedStreet,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedStreet, salesConsultant.Address.Street);
    }
    
    [Fact]
    public void GivenValidNumber_WhenCreatingSalesConsultant_ThenShouldHaveValidNumber()
    {
        // Arrange
        const int expectedNumber = 123;

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            expectedNumber,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedNumber, salesConsultant.Address.Number);
    }
    
    [Fact]
    public void GivenValidComplement_WhenCreatingSalesConsultant_ThenShouldHaveValidComplement()
    {
        // Arrange
        const string expectedComplement = "Casa";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            expectedComplement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedComplement, salesConsultant.Address.Complement);
    }
    
    [Fact]
    public void GivenValidZipCode_WhenCreatingSalesConsultant_ThenShouldHaveValidZipCode()
    {
        // Arrange
        const string expectedZipCode = "22790147";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            expectedZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedZipCode, salesConsultant.Address.ZipCode);
    }
    
    [Fact]
    public void GivenValidNeighborhood_WhenCreatingSalesConsultant_ThenShouldHaveValidNeighborhood()
    {
        // Arrange
        const string expectedNeighborhood = "Barra da Tijuca";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            expectedNeighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedNeighborhood, salesConsultant.Address.Neighborhood);
    }
    
    [Fact]
    public void GivenValidCity_WhenCreatingSalesConsultant_ThenShouldHaveValidCity()
    {
        // Arrange
        const string expectedCity = "Petropolis";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            expectedCity,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedCity, salesConsultant.Address.City);
    }
    
    [Fact]
    public void GivenValidState_WhenCreatingSalesConsultant_ThenShouldHaveValidState()
    {
        // Arrange
        const string expectedState = "Rio de Janeiro";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            expectedState,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedState, salesConsultant.Address.State);
    }
    
    [Fact]
    public void GivenValidCountry_WhenCreatingSalesConsultant_ThenShouldHaveValidCountry()
    {
        // Arrange
        const string expectedCountry = "Brasil";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            expectedCountry,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedCountry, salesConsultant.Address.Country);
    }
    
    [Fact]
    public void GivenValidName_WhenCreatingSalesConsultant_ThenShouldHaveValidName()
    {
        // Arrange
        const string expectedName = "Joao da Silva";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            expectedName,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedName, salesConsultant.Name);
    }
    
    [Fact]
    public void GivenValidEmailValue_WhenCreatingSalesConsultant_ThenShouldHaveValidEmailValue()
    {
        // Arrange
        const string expectedEmailValue = "email@email.com";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            expectedEmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedEmailValue, salesConsultant.Email.Format());
    }
    
    [Fact]
    public void GivenValidLandline_WhenCreatingSalesConsultant_ThenShouldHaveValidLandline()
    {
        // Arrange
        const string expectedLandline = "21998345677";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            expectedLandline,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedLandline, salesConsultant.Landline?.Value);
    }
    
    [Fact]
    public void GivenValidMobile_WhenCreatingSalesConsultant_ThenShouldHaveValidMobile()
    {
        // Arrange
        const string expectedMobile = "21998345677";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            expectedMobile
        );

        // Assert
        Assert.Equal(expectedMobile, salesConsultant.Landline?.Value);
    }
    
    [Theory]
    [InlineData("", "Rua John", 1234, "Casa", "64546-810", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "Brasil", "Nomeee", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "", 1234, "Casa", "64546-810", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "Brasil", "Nomeee", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", -1, "Casa", "64546-810", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "Brasil", "Nomeee", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "", "64546-810", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "Brasil", "Nomeee", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "Casa", "", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "Brasil", "Nomeee", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "Casa", "64546-810", "", "Petropolis", "Rio de Janeiro", "Brasil", "Nomeee", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "Casa", "64546-810", "Barra da Tijuca", "", "Rio de Janeiro", "Brasil", "Nomeee", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "Casa", "64546-810", "Barra da Tijuca", "Petropolis", "", "Brasil", "Nomeee", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "Casa", "64546-810", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "", "Nomeee", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "Casa", "64546-810", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "Brasil", "", "email@email.com", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "Casa", "64546-810", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "Brasil", "Nomeee", "", "2422546870", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "Casa", "64546-810", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "Brasil", "Nomeee", "email@email.com", "", "24954365490")]
    [InlineData("143.356.745-20", "Rua John", 1234, "Casa", "64546-810", "Barra da Tijuca", "Petropolis", "Rio de Janeiro", "Brasil", "Nomeee", "email@email.com", "2422546870", "")]
    public void GivenInvalidInput_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage(
        string cpfValue,
        string street,
        int number,
        string complement,
        string zipCode,
        string neighborhood,
        string city,
        string state,
        string country,
        string name,
        string emailValue,
        string phoneValue,
        string mobile
    )
    {
        // Arrange
        const string expectedErrorMessage = "There are validation errors.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    cpfValue,
                    street,
                    number,
                    complement,
                    zipCode,
                    neighborhood,
                    city,
                    state,
                    country,
                    name,
                    emailValue,
                    phoneValue,
                    mobile
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenEmptyCpf_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyCpf = "";
        const string expectedErrorMessage = "'CPF' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    emptyCpf,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceCpf_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceCpf = "             ";
        const string expectedErrorMessage = "'CPF' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    whitespaceCpf,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortCpf_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortCpf = Constants.InvalidCpf.ShortCpf;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    shortCpf,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongCpf_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longCpf = Constants.InvalidCpf.LongCpf;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    longCpf,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidLastDigitCpf_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string invalidLastDigitCpf = Constants.InvalidCpf.InvalidCpfLastDigit;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    invalidLastDigitCpf,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenNonNumericCpf_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericCpf = Constants.InvalidCpf.NonNumericCpf;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    nonNumericCpf,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyStreet_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyStreet = "";
        const string expectedErrorMessage = "'Street' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    emptyStreet,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceStreet_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceStreet = "             ";
        const string expectedErrorMessage = "'Street' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    whitespaceStreet,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortStreet_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortStreet = Constants.InvalidAddress.ShortStreet;
        const string expectedErrorMessage = "'Street' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    shortStreet,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongStreet_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longStreet = Constants.InvalidAddress.LongStreet;
        const string expectedErrorMessage = "'Street' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    longStreet,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenInvalidNumber_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const int invalidNumber = Constants.InvalidAddress.InvalidNumber;
        const string expectedErrorMessage = "'Number' should be a positive int.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    invalidNumber,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongComplement_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longComplement = Constants.InvalidAddress.LongComplement;
        const string expectedErrorMessage = "'Complement' should be between 0 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    longComplement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyZipCode_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyZipCode = "";
        const string expectedErrorMessage = "'Zip Code' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    emptyZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceZipCode_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceZipCode = "             ";
        const string expectedErrorMessage = "'Zip Code' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    whitespaceZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortZipCode_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortZipCode = Constants.InvalidAddress.ShortZipCode;
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    shortZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongZipCode_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longZipCode = Constants.InvalidAddress.LongZipCode;
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    longZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenNonNumericZipCode_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericZipCode = Constants.InvalidAddress.NonNumericZipCode;
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    nonNumericZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyNeighborhood_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyNeighborhood = "";
        const string expectedErrorMessage = "'Neighborhood' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    emptyNeighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceNeighborhood_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceNeighborhood = "             ";
        const string expectedErrorMessage = "'Neighborhood' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    whitespaceNeighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortNeighborhood_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortNeighborhood = Constants.InvalidAddress.ShortNeighborhood;
        const string expectedErrorMessage = "'Neighborhood' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    shortNeighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongNeighborhood_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longNeighborhood = Constants.InvalidAddress.LongNeighborhood;
        const string expectedErrorMessage = "'Neighborhood' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    longNeighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyCity_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyCity = "";
        const string expectedErrorMessage = "'City' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    emptyCity,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceCity_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceCity = "             ";
        const string expectedErrorMessage = "'City' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    whitespaceCity,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortCity_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortCity = Constants.InvalidAddress.ShortCity;
        const string expectedErrorMessage = "'City' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    shortCity,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongCity_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longCity = Constants.InvalidAddress.LongCity;
        const string expectedErrorMessage = "'City' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    longCity,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyState_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyState = "";
        const string expectedErrorMessage = "'State' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    emptyState,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceState_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceState = "             ";
        const string expectedErrorMessage = "'State' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    whitespaceState,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortState_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortState = Constants.InvalidAddress.ShortState;
        const string expectedErrorMessage = "'State' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    shortState,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongState_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longState = Constants.InvalidAddress.LongState;
        const string expectedErrorMessage = "'State' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    longState,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyCountry_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyCountry = "";
        const string expectedErrorMessage = "'Country' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    emptyCountry,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceCountry_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceCountry = "             ";
        const string expectedErrorMessage = "'Country' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    whitespaceCountry,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortCountry_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortCountry = Constants.InvalidAddress.ShortCountry;
        const string expectedErrorMessage = "'Country' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    shortCountry,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongCountry_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longCountry = Constants.InvalidAddress.LongCountry;
        const string expectedErrorMessage = "'Country' should be between 3 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    longCountry,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyName_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyName = "";
        const string expectedErrorMessage = "'Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    emptyName,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceName_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceName = "             ";
        const string expectedErrorMessage = "'Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    whitespaceName,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortName_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortName = Constants.InvalidSalesConsultant.ShortName;
        const string expectedErrorMessage = "'Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    shortName,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongName_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longName = Constants.InvalidSalesConsultant.LongName;
        const string expectedErrorMessage = "'Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    longName,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyEmailValue_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyEmailValue = "";
        const string expectedErrorMessage = "'Email Address' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    emptyEmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceEmailValue_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceEmailValue = "             ";
        const string expectedErrorMessage = "'Email Address' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    whitespaceEmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortEmailValue_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortEmailValue = Constants.InvalidEmail.ShortEmailAddress;
        const string expectedErrorMessage = "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    shortEmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongEmailValue_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longEmailValue = Constants.InvalidEmail.LongEmailAddress;
        const string expectedErrorMessage = "'Email Address' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    longEmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyLandline_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyLandline = "";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    emptyLandline,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceLandline_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceLandline = "             ";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    whitespaceLandline,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortLandline_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortLandline = Constants.InvalidPhone.ShortPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    shortLandline,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongLandline_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longLandline = Constants.InvalidPhone.LongPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    longLandline,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenEmptyMobile_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyMobile = "";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    emptyMobile
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceMobile_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceMobile = "             ";
        const string expectedErrorMessage = "'Phone Number' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    whitespaceMobile
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenShortMobile_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortMobile = Constants.InvalidPhone.ShortPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    shortMobile
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongMobile_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longMobile = Constants.InvalidPhone.LongPhone;
        const string expectedErrorMessage = "'Phone Number' should be between 8 and 18 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.SalesConsultant.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    longMobile
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenUntrimmedCpf_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedCpf()
    {
        // Arrange
        const string untrimmedCpf = "    54647142949       ";
        const string expectedCpf = "546.471.429-49";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            untrimmedCpf,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedCpf, salesConsultant.Cpf.Format());
    }
    
    [Fact]
    public void GivenUntrimmedStreet_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedStreet()
    {
        // Arrange
        const string untrimmedStreet = "    Rua da rua       ";
        const string expectedStreet = "Rua da rua";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            untrimmedStreet,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedStreet, salesConsultant.Address.Street);
    }
    
    [Fact]
    public void GivenUntrimmedComplement_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedComplement()
    {
        // Arrange
        const string untrimmedComplement = "    Casa       ";
        const string expectedComplement = "Casa";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            untrimmedComplement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedComplement, salesConsultant.Address.Complement);
    }
    
    [Fact]
    public void GivenUntrimmedZipCode_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedZipCode()
    {
        // Arrange
        const string untrimmedZipCode = " 87657-012 ";
        const string expectedZipCode = "87657012";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            untrimmedZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedZipCode, salesConsultant.Address.ZipCode);
    }
    
    [Fact]
    public void GivenUntrimmedNeighborhood_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedNeighborhood()
    {
        // Arrange
        const string untrimmedNeighborhood = "    Barra da tijuca       ";
        const string expectedNeighborhood = "Barra da tijuca";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            untrimmedNeighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedNeighborhood, salesConsultant.Address.Neighborhood);
    }
    
    [Fact]
    public void GivenUntrimmedCity_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedCity()
    {
        // Arrange
        const string untrimmedCity = "    Rio de Janeiro       ";
        const string expectedCity = "Rio de Janeiro";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            untrimmedCity,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedCity, salesConsultant.Address.City);
    }
    
    [Fact]
    public void GivenUntrimmedState_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedState()
    {
        // Arrange
        const string untrimmedState = "    Rio de Janeiro       ";
        const string expectedState = "Rio de Janeiro";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            untrimmedState,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedState, salesConsultant.Address.State);
    }
    
    [Fact]
    public void GivenUntrimmedCountry_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedCountry()
    {
        // Arrange
        const string untrimmedCountry = "    Rio de Janeiro       ";
        const string expectedCountry = "Rio de Janeiro";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            untrimmedCountry,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedCountry, salesConsultant.Address.Country);
    }
    
    [Fact]
    public void GivenUntrimmedName_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedName()
    {
        // Arrange
        const string untrimmedName = "  Joao Silva  ";
        const string expectedName = "Joao Silva";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            untrimmedName,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedName, salesConsultant.Name);
    }
    
    [Fact]
    public void GivenUntrimmedEmailValue_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedEmailValue()
    {
        // Arrange
        const string untrimmedEmailValue = "    email@email.com       ";
        const string expectedEmailValue = "email@email.com";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            untrimmedEmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedEmailValue, salesConsultant.Email.Format());
    }
    
    [Fact]
    public void GivenUntrimmedLandline_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedLandline()
    {
        // Arrange
        const string untrimmedLandline = "    21998345677       ";
        const string expectedLandline = "21998345677";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            untrimmedLandline,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedLandline, salesConsultant.Landline?.Value);
    }
    
    [Fact]
    public void GivenUntrimmedMobile_WhenCreatingSalesConsultant_ThenShouldHaveTrimmedMobile()
    {
        // Arrange
        const string untrimmedMobile = "    21998345677       ";
        const string expectedMobile = "21998345677";

        // Act
        var salesConsultant = Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.SalesConsultant.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            untrimmedMobile
        );

        // Assert
        Assert.Equal(expectedMobile, salesConsultant.Mobile?.Value);
    }
}
