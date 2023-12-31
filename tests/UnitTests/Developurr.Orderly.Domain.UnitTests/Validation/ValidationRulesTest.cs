using Developurr.Orderly.Domain.UnitTests.TestUtils.ValidationRules;
using Developurr.Orderly.Domain.Validation;
using Moq;

namespace Developurr.Orderly.Domain.UnitTests.Validation;

public sealed class ValidationRulesTest
{
    // [Theory]
    // [MemberData(
    //     nameof(EmailGenerator.CreateInvalidEmailAddresses),
    //     MemberType = typeof(EmailGenerator)
    // )]
    // public void GivenInvalidEmail_WhenValidatingEmail_ThenShouldCallAddValidatorError(
    //     string invalidEmail
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateEmail(invalidEmail, "email", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Once);
    // }
    //
    // [Theory]
    // [MemberData(nameof(EmailGenerator.CreateEmails), MemberType = typeof(EmailGenerator))]
    // public void GivenValidEmailAddress_WhenValidatingEmailAddress_ThenShouldDoNothing(Email email)
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateEmail(email.Value, "email", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Never);
    // }

    // [Theory]
    // [MemberData(nameof(CpfGenerator.CreateInvalidCpfs), MemberType = typeof(CpfGenerator))]
    // public void GivenInvalidCpfValue_WhenValidatingCpfValue_ThenShouldCallAddValidatorError(
    //     string invalidCpf
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateCpf(invalidCpf, "cpf", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Once);
    // }

    // [Theory]
    // [MemberData(nameof(CpfGenerator.CreateCpfs), MemberType = typeof(CpfGenerator))]
    // public void GivenValidCpfValue_WhenValidatingCpfValue_GivenValidCpfValue_ThenShouldDoNothing(
    //     Cpf invalidCpf
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateCpf(invalidCpf.Format(), "cpf", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Never);
    // }

    // [Theory]
    // [MemberData(nameof(CnpjGenerator.CreateInvalidCnpjValues), MemberType = typeof(CnpjGenerator))]
    // public void GivenInvalidCnpjValue_WhenValidatingCnpjValue_ThenShouldShouldCallAddValidatorError(
    //     string invalidCnpj
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateCnpj(invalidCnpj, "cnpj", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Once);
    // }

    // [Theory]
    // [MemberData(nameof(CnpjGenerator.CreateCnpjs), MemberType = typeof(CnpjGenerator))]
    // public void GivenValidCnpjValue_WhenValidatingCnpjValue_ThenShouldDoNothing(Cnpj cnpj)
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateCnpj(cnpj.Format(), "cnpj", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Never);
    // }

    // [Theory]
    // [MemberData(
    //     nameof(AddressGenerator.CreateInvalidNumbers),
    //     MemberType = typeof(AddressGenerator)
    // )]
    // public void GivenInvalidInt_WhenValidatingPositiveInt_ThenShouldCallAddValidatorError(
    //     int invalidNumber
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidatePositive(invalidNumber, "number", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Once);
    // }

    // [Theory]
    // [MemberData(nameof(AddressGenerator.CreateAddresses), MemberType = typeof(AddressGenerator))]
    // public void GivenValidInt_WhenValidatingPositiveInt_ThenShouldDoNothing(Address number)
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidatePositive(number.Number, "number", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Never);
    // }

    // [Theory]
    // [MemberData(nameof(PriceGenerator.CreateInvalidPrices), MemberType = typeof(PriceGenerator))]
    // public void GivenInvalidDecimal_WhenValidatingPositiveDecimal_ThenShouldCallAddValidatorError(
    //     decimal invalidNumber
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidatePositive(invalidNumber, "number", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Once);
    // }
    //
    // [Theory]
    // [MemberData(nameof(PriceGenerator.CreatePrices), MemberType = typeof(PriceGenerator))]
    // public void GivenValidDecimal_WhenValidatingPositiveDecimal_ThenShouldDoNothing(Price number)
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidatePositive(number.Value, "number", validatorMock.Object);
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Never);
    // }

    // [Theory]
    // [MemberData(
    //     nameof(AddressGenerator.CreateInvalidComplements),
    //     MemberType = typeof(AddressGenerator)
    // )]
    // public void GivenInvalidStringLength_WhenValidatingMaxStringLength_ThenShouldCallAddValidatorError(
    //     string invalidString
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateMaxStringLength(
    //         invalidString,
    //         "string",
    //         AddressValidatorConfig.ComplementMaxLength,
    //         validatorMock.Object
    //     );
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Once);
    // }

    // [Theory]
    // [MemberData(nameof(AddressGenerator.CreateAddresses), MemberType = typeof(AddressGenerator))]
    // public void GivenValidStringLength_WhenValidatingMaxStringLength_ThenShouldDoNothing(
    //     Address address
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateMaxStringLength(
    //         address.Complement,
    //         "string",
    //         AddressValidatorConfig.ComplementMaxLength,
    //         validatorMock.Object
    //     );
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Never);
    // }

    // [Theory]
    // [MemberData(
    //     nameof(AddressGenerator.CreateInvalidStreets),
    //     MemberType = typeof(AddressGenerator)
    // )]
    // public void GivenInvalidStringLength_WhenValidatingStringLength_ThenShouldCallAddValidatorError(
    //     string invalidString
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateStringLength(
    //         invalidString,
    //         "string",
    //         AddressValidatorConfig.StreetMinLength,
    //         AddressValidatorConfig.StreetMaxLength,
    //         validatorMock.Object
    //     );
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Once);
    // }

    // [Theory]
    // [MemberData(nameof(AddressGenerator.CreateAddresses), MemberType = typeof(AddressGenerator))]
    // public void GivenValidStringLength_WhenValidatingStringLength_ThenShouldDoNothing(
    //     Address address
    // )
    // {
    //     // Arrange
    //     var validatorMock = ValidationRulesFixture.GetValidatorMock();
    //
    //     // Act
    //     ValidationRules.ValidateStringLength(
    //         address.Street,
    //         "string",
    //         AddressValidatorConfig.StreetMinLength,
    //         AddressValidatorConfig.StreetMaxLength,
    //         validatorMock.Object
    //     );
    //
    //     // Assert
    //     validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Never);
    // }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("  ")]
    public void GivenInvalidRequired_WhenValidatingRequired_ThenShouldCallAddValidatorError(
        string invalidString
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateRequired(invalidString, "string", validatorMock.Object);

        // Assert
        validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Once);
    }

    [Theory]
    [InlineData("validString1")]
    [InlineData("validString2")]
    [InlineData("validString3")]
    public void GivenValidRequired_WhenValidatingRequired_ThenShouldDoNothing(string testString)
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateRequired(testString, "string", validatorMock.Object);

        // Assert
        validatorMock.Verify(val => val.AddValidationError(It.IsAny<string>()), Times.Never);
    }
}
