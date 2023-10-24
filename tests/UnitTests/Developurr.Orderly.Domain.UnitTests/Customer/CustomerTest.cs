using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Cnpj;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Email;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Phone;
using Developurr.Orderly.Domain.UnitTests.TestUtils.VendorId;

namespace Developurr.Orderly.Domain.UnitTests.Customer;

public sealed class CustomerTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingCustomer_ThenShouldInstantiateCustomer()
    {
        // Arrange
        var vendorId = VendorIdFixture.GenerateId();
        var cnpj = CnpjFixture.CreateCnpj();
        var corporateName = NonEmptyTextFixture.CreateNonEmptyText();
        var taxId = NonEmptyTextFixture.CreateNonEmptyText();
        var tradeName = NonEmptyTextFixture.CreateNonEmptyText();
        var segment = NonEmptyTextFixture.CreateNonEmptyText();
        var billingEmail = EmailFixture.CreateEmail();
        var nfeEmail = EmailFixture.CreateEmail();
        var landline = PhoneFixture.CreatePhone();
        var mobile = PhoneFixture.CreatePhone();
        var observation = OptionalTextFixture.CreateOptionalText();

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            vendorId,
            cnpj.ToString(),
            corporateName.ToString(),
            taxId.ToString(),
            tradeName.ToString(),
            segment.ToString(),
            billingEmail.ToString(),
            nfeEmail.ToString(),
            landline.ToString(),
            mobile.ToString(),
            observation.ToString()
        );

        // Assert
        Assert.NotNull(customer);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingCustomer_ThenShouldHaveValidId()
    {
        // Arrange
        var vendorId = VendorIdFixture.GenerateId();
        var cnpj = CnpjFixture.CreateCnpj();
        var corporateName = NonEmptyTextFixture.CreateNonEmptyText();
        var taxId = NonEmptyTextFixture.CreateNonEmptyText();
        var tradeName = NonEmptyTextFixture.CreateNonEmptyText();
        var segment = NonEmptyTextFixture.CreateNonEmptyText();
        var billingEmail = EmailFixture.CreateEmail();
        var nfeEmail = EmailFixture.CreateEmail();
        var landline = PhoneFixture.CreatePhone();
        var mobile = PhoneFixture.CreatePhone();
        var observation = OptionalTextFixture.CreateOptionalText();

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            vendorId,
            cnpj.ToString(),
            corporateName.ToString(),
            taxId.ToString(),
            tradeName.ToString(),
            segment.ToString(),
            billingEmail.ToString(),
            nfeEmail.ToString(),
            landline.ToString(),
            mobile.ToString(),
            observation.ToString()
        );

        // Assert
        Assert.NotNull(customer.Id);
    }

    // Active test
    [Fact]
    public void GivenValidInput_WhenCreatingCustomer_ThenShouldHaveActiveStatusTrue()
    {
        // Arrange
        var vendorId = VendorIdFixture.GenerateId();
        var cnpj = CnpjFixture.CreateCnpj();
        var corporateName = NonEmptyTextFixture.CreateNonEmptyText();
        var taxId = NonEmptyTextFixture.CreateNonEmptyText();
        var tradeName = NonEmptyTextFixture.CreateNonEmptyText();
        var segment = NonEmptyTextFixture.CreateNonEmptyText();
        var billingEmail = EmailFixture.CreateEmail();
        var nfeEmail = EmailFixture.CreateEmail();
        var landline = PhoneFixture.CreatePhone();
        var mobile = PhoneFixture.CreatePhone();
        var observation = OptionalTextFixture.CreateOptionalText();

        // Act
        var customer = Developurr.Orderly.Domain.Customer.Customer.Create(
            vendorId,
            cnpj.ToString(),
            corporateName.ToString(),
            taxId.ToString(),
            tradeName.ToString(),
            segment.ToString(),
            billingEmail.ToString(),
            nfeEmail.ToString(),
            landline.ToString(),
            mobile.ToString(),
            observation.ToString()
        );

        // Assert
        Assert.True(customer.Active.IsActive);
    }

    [Theory]
    [InlineData(
        "",
        "Corporate Name",
        "12345",
        "Trade Name",
        "Segment",
        "email@email.com",
        "email@email.com",
        "2422546870",
        "24954365490",
        "Observation"
    )]
    [InlineData(
        "59.546.515/0001-34",
        "",
        "12345",
        "Trade Name",
        "Segment",
        "email@email.com",
        "email@email.com",
        "2422546870",
        "24954365490",
        "Observation"
    )]
    [InlineData(
        "59.546.515/0001-34",
        "Corporate Name",
        "",
        "Trade Name",
        "Segment",
        "email@email.com",
        "email@email.com",
        "2422546870",
        "24954365490",
        "Observation"
    )]
    [InlineData(
        "59.546.515/0001-34",
        "Corporate Name",
        "12345",
        "",
        "Segment",
        "email@email.com",
        "email@email.com",
        "2422546870",
        "24954365490",
        "Observation"
    )]
    [InlineData(
        "59.546.515/0001-34",
        "Corporate Name",
        "12345",
        "Trade Name",
        "",
        "email@email.com",
        "email@email.com",
        "2422546870",
        "24954365490",
        "Observation"
    )]
    [InlineData(
        "59.546.515/0001-34",
        "Corporate Name",
        "12345",
        "Trade Name",
        "Segment",
        "",
        "email@email.com",
        "2422546870",
        "24954365490",
        "Observation"
    )]
    [InlineData(
        "59.546.515/0001-34",
        "Corporate Name",
        "12345",
        "Trade Name",
        "Segment",
        "email@email.com",
        "",
        "2422546870",
        "24954365490",
        "Observation"
    )]
    [InlineData(
        "59.546.515/0001-34",
        "Corporate Name",
        "12345",
        "Trade Name",
        "Segment",
        "email@email.com",
        "email@email.com",
        "",
        "24954365490",
        "Observation"
    )]
    [InlineData(
        "59.546.515/0001-34",
        "Corporate Name",
        "12345",
        "Trade Name",
        "Segment",
        "email@email.com",
        "email@email.com",
        "2422546870",
        "",
        "Observation"
    )]
    [InlineData(
        "59.546.515/0001-34",
        "Corporate Name",
        "12345",
        "Trade Name",
        "Segment",
        "email@email.com",
        "email@email.com",
        "2422546870",
        "24954365490",
        ""
    )]
    public void GivenInvalidInput_WhenCreatingCustomer_ThenShouldThrowEntityValidationExceptionWithMessage(
        string cnpj,
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
        var vendorId = VendorIdFixture.GenerateId();
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    vendorId,
                    cnpj,
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
        var domainValidationException = Assert.IsType<ValidationException>(exception);
        Assert.Contains(expectedErrorMessage, domainValidationException.Message);
    }

    [Theory]
    [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void GivenInvalidInput_WhenCreatingCustomer_ThenEntityValidationExceptionShouldContainMessage(
        string expectedMessage
    )
    {
        // Assert
        var vendorId = VendorIdFixture.GenerateId();
        var cnpj = CnpjFixture.CreateInvalidCnpj();
        var corporateName = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        var taxId = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        var tradeName = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        var segment = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        var billingEmail = EmailFixture.CreateInvalidEmail();
        var nfeEmail = EmailFixture.CreateInvalidEmail();
        var landline = PhoneFixture.CreateInvalidPhone();
        var mobile = PhoneFixture.CreateInvalidPhone();
        var observation = OptionalTextFixture.CreateInvalidOptionalText();

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Customer.Customer.Create(
                    vendorId,
                    cnpj,
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
        var domainValidationException = Assert.IsType<ValidationException>(exception);
        // Assert.Contains(expectedMessage, domainValidationException.ValidationMessages);
    }
}