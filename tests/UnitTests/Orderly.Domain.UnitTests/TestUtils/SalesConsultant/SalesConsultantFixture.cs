using Orderly.Domain.SalesConsultant.Validators;
using Orderly.Domain.UnitTests.TestUtils.Address;
using Orderly.Domain.UnitTests.TestUtils.Cpf;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.Phone;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

public sealed class SalesConsultantFixture : BaseFixture
{
    private static Domain.SalesConsultant.SalesConsultant CreateValidSalesConsultant()
    {
        var cpf = CpfFixture.CreateCpf();
        var address = AddressFixture.CreateAddress();
        var email = EmailFixture.CreateEmail();
        var landline = PhoneFixture.CreatePhone();
        var mobile = PhoneFixture.CreatePhone();

        var name = StringFixture.CreateString(
            SalesConsultantValidator.NameMinLength,
            SalesConsultantValidator.NameMaxLength
        );

        return Domain.SalesConsultant.SalesConsultant.Create(
            cpf.Value,
            address.Street,
            address.Number,
            address.Complement,
            address.ZipCode,
            address.Neighborhood,
            address.City,
            address.State,
            address.Country,
            name,
            email.Value,
            landline.Value,
            mobile.Value
        );
    }

    public static Domain.SalesConsultant.SalesConsultant CreateSalesConsultant(
        Domain.SalesConsultant.SalesConsultant? salesConsultant = null,
        string? name = null
    )
    {
        var lSalesConsultant = salesConsultant ?? CreateValidSalesConsultant();

        return Domain.SalesConsultant.SalesConsultant.Create(
            lSalesConsultant.Cpf.Value,
            lSalesConsultant.Address.Street,
            lSalesConsultant.Address.Number,
            lSalesConsultant.Address.Complement,
            lSalesConsultant.Address.ZipCode,
            lSalesConsultant.Address.Neighborhood,
            lSalesConsultant.Address.City,
            lSalesConsultant.Address.State,
            lSalesConsultant.Address.Country,
            name ?? lSalesConsultant.Name,
            lSalesConsultant.Email.Value,
            lSalesConsultant.Landline?.Value,
            lSalesConsultant.Mobile?.Value
        );
    }

    public static string CreateShortName()
    {
        return StringFixture.CreateString(1, SalesConsultantValidator.NameMinLength - 1);
    }

    public static string CreateLongName()
    {
        return StringFixture.CreateString(SalesConsultantValidator.NameMaxLength + 1, 1_000);
    }
}
