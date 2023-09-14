using Orderly.Domain.SalesConsultant.Validators;
using Orderly.Domain.UnitTests.TestUtils.Address;
using Orderly.Domain.UnitTests.TestUtils.Cpf;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.Phone;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

public class SalesConsultantFixture : BaseFixture
{
    public static Domain.SalesConsultant.SalesConsultant CreateSalesConsultant()
    {
        var cpf = CpfFixture.CreateValidCpf();
        var address = AddressFixture.CreateAddress();
        var name = StringFixture.CreateString(
            SalesConsultantValidator.NameMinLength,
            SalesConsultantValidator.NameMaxLength
        );
        var email = EmailFixture.CreateEmail();
        var landline = PhoneFixture.CreatePhone();
        var mobile = PhoneFixture.CreatePhone();

        return Domain.SalesConsultant.SalesConsultant.Create(
            cpf,
            address,
            name,
            email,
            landline,
            mobile
        );
    }


    public static string CreateShortName()
    {
        return StringFixture.CreateString(
            1,
            SalesConsultantValidator.NameMinLength - 1
        );
    }


    public static string CreateLongName()
    {
        return StringFixture.CreateString(
            SalesConsultantValidator.NameMaxLength + 1,
            1_000
        );
    }
}