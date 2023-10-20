using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Vendor;

public sealed class VendorTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingVendor_ThenShouldInstantiateVendor()
    {
        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.NotNull(vendor);
    }
    
    [Fact]
    public void GivenValidCpf_WhenCreatingVendor_ThenShouldHaveValidCpf()
    {
        // Arrange
        const string cpf = "54647142949";
        const string expectedCpf = "546.471.429-49";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            cpf,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedCpf, vendor.Cpf.Format());
    }
    
    [Fact]
    public void GivenValidStreet_WhenCreatingVendor_ThenShouldHaveValidStreet()
    {
        // Arrange
        const string expectedStreet = "Rua john";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            expectedStreet,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedStreet, vendor.Address.Street);
    }
    
    [Fact]
    public void GivenValidNumber_WhenCreatingVendor_ThenShouldHaveValidNumber()
    {
        // Arrange
        const int expectedNumber = 123;

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            expectedNumber,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedNumber, vendor.Address.Number);
    }
    
    [Fact]
    public void GivenValidComplement_WhenCreatingVendor_ThenShouldHaveValidComplement()
    {
        // Arrange
        const string expectedComplement = "Casa";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            expectedComplement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedComplement, vendor.Address.Complement);
    }
    
    [Fact]
    public void GivenValidZipCode_WhenCreatingVendor_ThenShouldHaveValidZipCode()
    {
        // Arrange
        const string expectedZipCode = "22790147";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            expectedZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedZipCode, vendor.Address.ZipCode);
    }
    
    [Fact]
    public void GivenValidNeighborhood_WhenCreatingVendor_ThenShouldHaveValidNeighborhood()
    {
        // Arrange
        const string expectedNeighborhood = "Barra da Tijuca";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            expectedNeighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedNeighborhood, vendor.Address.Neighborhood);
    }
    
    [Fact]
    public void GivenValidCity_WhenCreatingVendor_ThenShouldHaveValidCity()
    {
        // Arrange
        const string expectedCity = "Petropolis";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            expectedCity,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedCity, vendor.Address.City);
    }
    
    [Fact]
    public void GivenValidState_WhenCreatingVendor_ThenShouldHaveValidState()
    {
        // Arrange
        const string expectedState = "Rio de Janeiro";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            expectedState,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedState, vendor.Address.State);
    }
    
    [Fact]
    public void GivenValidCountry_WhenCreatingVendor_ThenShouldHaveValidCountry()
    {
        // Arrange
        const string expectedCountry = "Brasil";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            expectedCountry,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedCountry, vendor.Address.Country);
    }
    
    [Fact]
    public void GivenValidName_WhenCreatingVendor_ThenShouldHaveValidName()
    {
        // Arrange
        const string expectedName = "Joao da Silva";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
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
        Assert.Equal(expectedName, vendor.Name);
    }
    
    [Fact]
    public void GivenValidEmailValue_WhenCreatingVendor_ThenShouldHaveValidEmailValue()
    {
        // Arrange
        const string expectedEmailValue = "email@email.com";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            expectedEmailValue,
            Constants.Phone.PhoneValue,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedEmailValue, vendor.Email.Format());
    }
    
    [Fact]
    public void GivenValidLandline_WhenCreatingVendor_ThenShouldHaveValidLandline()
    {
        // Arrange
        const string expectedLandline = "21998345677";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            expectedLandline,
            Constants.Phone.PhoneValue
        );

        // Assert
        Assert.Equal(expectedLandline, vendor.Landline?.Value);
    }
    
    [Fact]
    public void GivenValidMobile_WhenCreatingVendor_ThenShouldHaveValidMobile()
    {
        // Arrange
        const string expectedMobile = "21998345677";

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            Constants.Cpf.CpfValue,
            Constants.Address.Street,
            Constants.Address.Number,
            Constants.Address.Complement,
            Constants.Address.ZipCode,
            Constants.Address.Neighborhood,
            Constants.Address.City,
            Constants.Address.State,
            Constants.Address.Country,
            Constants.Vendor.Name,
            Constants.Email.EmailValue,
            Constants.Phone.PhoneValue,
            expectedMobile
        );

        // Assert
        Assert.Equal(expectedMobile, vendor.Landline?.Value);
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
    public void GivenInvalidInput_WhenCreatingVendor_ThenShouldThrowEntityValidationExceptionWithMessage(
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
                Domain.Vendor.Vendor.Create(
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
    public void GivenInvalidLastDigitCpf_WhenCreatingVendor_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string invalidLastDigitCpf = Constants.InvalidCpf.InvalidCpfLastDigit;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Domain.Vendor.Vendor.Create(
                    invalidLastDigitCpf,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.Vendor.Name,
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
    public void GivenNonNumericCpf_WhenCreatingVendor_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericCpf = Constants.InvalidCpf.NonNumericCpf;
        const string expectedErrorMessage = "'CPF' is not valid.";

        // Act
        var exception = Record.Exception(
            () =>
                Domain.Vendor.Vendor.Create(
                    nonNumericCpf,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.Vendor.Name,
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
    public void GivenInvalidNumber_WhenCreatingVendor_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const int invalidNumber = Constants.InvalidAddress.InvalidNumber;
        const string expectedErrorMessage = "'Number' should be a positive int.";

        // Act
        var exception = Record.Exception(
            () =>
                Domain.Vendor.Vendor.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    invalidNumber,
                    Constants.Address.Complement,
                    Constants.Address.ZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.Vendor.Name,
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
    public void GivenNonNumericZipCode_WhenCreatingVendor_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string nonNumericZipCode = Constants.InvalidAddress.NonNumericZipCode;
        const string expectedErrorMessage = "Invalid 'Zip Code' format.";

        // Act
        var exception = Record.Exception(
            () =>
                Domain.Vendor.Vendor.Create(
                    Constants.Cpf.CpfValue,
                    Constants.Address.Street,
                    Constants.Address.Number,
                    Constants.Address.Complement,
                    nonNumericZipCode,
                    Constants.Address.Neighborhood,
                    Constants.Address.City,
                    Constants.Address.State,
                    Constants.Address.Country,
                    Constants.Vendor.Name,
                    Constants.Email.EmailValue,
                    Constants.Phone.PhoneValue,
                    Constants.Phone.PhoneValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
}
