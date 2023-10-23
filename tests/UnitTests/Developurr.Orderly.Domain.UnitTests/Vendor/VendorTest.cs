using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Cpf;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Email;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Phone;

namespace Developurr.Orderly.Domain.UnitTests.Vendor;

public sealed class VendorTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingVendor_ThenShouldInstantiateVendor()
    {
        // Arrange
        var cpf = CpfFixture.CreateCpf();
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        const string zipCode = "12345-678"; // ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var email = EmailFixture.CreateEmail();
        var landline = PhoneFixture.CreatePhone();
        var mobile = PhoneFixture.CreatePhone();

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            cpf.ToString(),
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString(),
            name.ToString(),
            email.ToString(),
            landline.ToString(),
            mobile.ToString()
        );

        // Assert
        Assert.NotNull(vendor);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingVendor_ThenShouldHaveValidId()
    {
        // Arrange
        var cpf = CpfFixture.CreateCpf();
        var street = NonEmptyTextFixture.CreateNonEmptyText();
        const int number = 110;
        var complement = OptionalTextFixture.CreateOptionalText();
        const string zipCode = "12345-678"; // ZipCodeFixture.CreateZipCode();
        var neighborhood = NonEmptyTextFixture.CreateNonEmptyText();
        var city = NonEmptyTextFixture.CreateNonEmptyText();
        var state = NonEmptyTextFixture.CreateNonEmptyText();
        var country = NonEmptyTextFixture.CreateNonEmptyText();
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var email = EmailFixture.CreateEmail();
        var landline = PhoneFixture.CreatePhone();
        var mobile = PhoneFixture.CreatePhone();

        // Act
        var vendor = Domain.Vendor.Vendor.Create(
            cpf.ToString(),
            street.ToString(),
            number,
            complement.ToString(),
            zipCode.ToString(),
            neighborhood.ToString(),
            city.ToString(),
            state.ToString(),
            country.ToString(),
            name.ToString(),
            email.ToString(),
            landline.ToString(),
            mobile.ToString()
        );

        // Assert
        Assert.NotNull(vendor.Id);
    }

    [Theory]
    [InlineData(
        "",
        "Rua John",
        1234,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "",
        1234,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        -1,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "Casa",
        "",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "Casa",
        "64546-810",
        "",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "",
        "Nomeee",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "",
        "email@email.com",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "",
        "2422546870",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "",
        "24954365490"
    )]
    [InlineData(
        "143.356.745-20",
        "Rua John",
        1234,
        "Casa",
        "64546-810",
        "Barra da Tijuca",
        "Petropolis",
        "Rio de Janeiro",
        "Brasil",
        "Nomeee",
        "email@email.com",
        "2422546870",
        ""
    )]
    public void GivenInvalidInput_WhenCreatingVendor_ThenShouldThrowEntityValidationExceptionWithMessage(
        string cpf,
        string street,
        int number,
        string complement,
        string zipCode,
        string neighborhood,
        string city,
        string state,
        string country,
        string name,
        string email,
        string landline,
        string mobile
    )
    {
        // Arrange
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(
            () =>
                Domain.Vendor.Vendor.Create(
                    cpf,
                    street,
                    number,
                    complement,
                    zipCode,
                    neighborhood,
                    city,
                    state,
                    country,
                    name,
                    email,
                    landline,
                    mobile
                )
        );

        // Assert
        var domainValidationException = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedErrorMessage, domainValidationException.Message);
    }

    [Theory]
    [InlineData("")]
    public void GivenInvalidInput_WhenCreatingVendor_ThenEntityValidationExceptionShouldContainMessage(
        string expectedMessage
    )
    {
        // Arrange
        var cpf = CpfFixture.CreateInvalidCpf();
        var street = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        const int number = -10;
        var complement = OptionalTextFixture.CreateInvalidOptionalText();
        const string zipCode = "12345-678"; // ZipCodeFixture.CreateInvalidZipCode();
        var neighborhood = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        var city = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        var state = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        var country = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        var name = NonEmptyTextFixture.CreateInvalidNonEmptyText();
        var email = EmailFixture.CreateInvalidEmail();
        var landline = PhoneFixture.CreateInvalidPhone();
        var mobile = PhoneFixture.CreateInvalidPhone();

        // Act
        var exception = Record.Exception(
            () =>
                Domain.Vendor.Vendor.Create(
                    cpf,
                    street,
                    number,
                    complement,
                    zipCode.ToString(),
                    neighborhood,
                    city,
                    state,
                    country,
                    name,
                    email,
                    landline,
                    mobile
                )
        );

        // Assert
        var domainValidationException = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedMessage, domainValidationException.Message);
    }
}
