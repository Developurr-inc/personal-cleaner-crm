using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Common.ValueObjects.Validators;
using Orderly.Domain.UnitTests.TestUtils.Address;
using Orderly.Domain.UnitTests.TestUtils.Cnpj;
using Orderly.Domain.UnitTests.TestUtils.Cpf;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.Price;
using Orderly.Domain.UnitTests.TestUtils.String;
using Orderly.Domain.UnitTests.TestUtils.ValidationRules;
using Orderly.Domain.Validation;
using Moq;

namespace Orderly.Domain.UnitTests.Validation;

public class ValidationRulesTest
{
    [Theory]
    [MemberData(nameof(EmailGenerator.CreateInvalidEmailAddresses), MemberType = typeof(EmailGenerator))]
    public void GivenInvalidEmail_WhenValidatingEmail_ThenShouldCallAddValidatorError(
        string invalidEmail
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateEmail(
            invalidEmail,
            "email",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Once
        );
    }


    [Theory]
    [MemberData(nameof(EmailGenerator.CreateEmails), MemberType = typeof(EmailGenerator))]
    public void GivenValidEmailAddress_WhenValidatingEmailAddress_ThenShouldDoNothing(
        Email email
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateEmail(
            email.Value,
            "email",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Never
        );
    }


    [Theory]
    [MemberData(nameof(CpfGenerator.CreateInvalidCpfs), MemberType = typeof(CpfGenerator))]
    public void GivenInvalidCpfValue_WhenValidatingCpfValue_ThenShouldCallAddValidatorError(
        string invalidCpf
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateCpf(
            invalidCpf,
            "cpf",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Once
        );
    }


    [Theory]
    [MemberData(nameof(CpfGenerator.CreateCpfs), MemberType = typeof(CpfGenerator))]
    public void GivenValidCpfValue_WhenValidatingCpfValue_GivenValidCpfValue_ThenShouldDoNothing(
        Cpf invalidCpf
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateCpf(
            invalidCpf.Value,
            "cpf",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Never
        );
    }


    [Theory]
    [MemberData(nameof(CnpjGenerator.CreateInvalidCnpjValues), MemberType = typeof(CnpjGenerator))]
    public void GivenInvalidCnpjValue_WhenValidatingCnpjValue_ThenShouldShouldCallAddValidatorError(
        string invalidCnpj
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateCnpj(
            invalidCnpj,
            "cnpj",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Once
        );
    }


    [Theory]
    [MemberData(nameof(CnpjGenerator.CreateCnpjs), MemberType = typeof(CnpjGenerator))]
    public void GivenValidCnpjValue_WhenValidatingCnpjValue_ThenShouldDoNothing(
        Cnpj cnpj
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateCnpj(
            cnpj.Value,
            "cnpj",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Never
        );
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidNumbers), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidInt_WhenValidatingPositiveInt_ThenShouldCallAddValidatorError(
        int invalidNumber
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidatePositive(
            invalidNumber,
            "number",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Once
        );
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateAddresses), MemberType = typeof(AddressGenerator))]
    public void GivenValidInt_WhenValidatingPositiveInt_ThenShouldDoNothing(
        Address number
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidatePositive(
            number.Number,
            "number",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Never
        );
    }


    [Theory]
    [MemberData(nameof(PriceGenerator.CreateInvalidPrices), MemberType = typeof(PriceGenerator))]
    public void GivenInvalidDecimal_WhenValidatingPositiveDecimal_ThenShouldCallAddValidatorError(
        decimal invalidNumber
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidatePositive(
            invalidNumber,
            "number",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Once
        );
    }


    [Theory]
    [MemberData(nameof(PriceGenerator.CreatePrices), MemberType = typeof(PriceGenerator))]
    public void GivenValidDecimal_WhenValidatingPositiveDecimal_ThenShouldDoNothing(
        Price number
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidatePositive(
            number.Value,
            "number",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Never
        );
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidComplements), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidStringLength_WhenValidatingMaxStringLength_ThenShouldCallAddValidatorError(
        string invalidString
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateMaxStringLength(
            invalidString,
            "string",
            AddressValidator.ComplementMaxLength,
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Once
        );
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateAddresses), MemberType = typeof(AddressGenerator))]
    public void GivenValidStringLength_WhenValidatingMaxStringLength_ThenShouldDoNothing(
        Address address
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateMaxStringLength(
            address.Complement,
            "string",
            AddressValidator.ComplementMaxLength,
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Never
        );
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateInvalidStreets), MemberType = typeof(AddressGenerator))]
    public void GivenInvalidStringLength_WhenValidatingStringLength_ThenShouldCallAddValidatorError(
        string invalidString
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateStringLength(
            invalidString,
            "string",
            AddressValidator.StreetMinLength,
            AddressValidator.StreetMaxLength,
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Once
        );
    }


    [Theory]
    [MemberData(nameof(AddressGenerator.CreateAddresses), MemberType = typeof(AddressGenerator))]
    public void GivenValidStringLength_WhenValidatingStringLength_ThenShouldDoNothing(
        Address address
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateStringLength(
            address.Street,
            "string",
            AddressValidator.StreetMinLength,
            AddressValidator.StreetMaxLength,
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Never
        );
    }


    [Theory]
    [MemberData(nameof(StringGenerator.CreateInvalidStrings), MemberType = typeof(StringGenerator))]
    public void GivenInvalidRequired_WhenValidatingRequired_ThenShouldCallAddValidatorError(
        string invalidString
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateRequired(
            invalidString,
            "string",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Once
        );
    }


    [Theory]
    [MemberData(nameof(StringGenerator.CreateStrings), MemberType = typeof(StringGenerator))]
    public void GivenValidRequired_WhenValidatingRequired_ThenShouldDoNothing(
        string testString
    )
    {
        // Arrange
        var validatorMock = ValidationRulesFixture.GetValidatorMock();

        // Act
        ValidationRules.ValidateRequired(
            testString,
            "string",
            validatorMock.Object
        );

        // Assert
        validatorMock.Verify(
            val => val.AddValidationError(
                It.IsAny<string>()
            ),
            Times.Never
        );
    }
}