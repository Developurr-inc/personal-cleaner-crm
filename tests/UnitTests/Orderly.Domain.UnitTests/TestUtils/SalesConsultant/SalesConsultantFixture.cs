using Orderly.Domain.SalesConsultant.Validators;
using Orderly.Domain.UnitTests.TestUtils.Address;
using Orderly.Domain.UnitTests.TestUtils.Cpf;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.Phone;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

public class SalesConsultantFixture : BaseFixture
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
            cpf,
            address,
            name,
            email,
            landline,
            mobile
        );
    }
    
    
    public static Domain.SalesConsultant.SalesConsultant CreateSalesConsultant(
        Domain.SalesConsultant.SalesConsultant? salesConsultant = null,
        string? name = null
    )
    {
        var lSalesConsultant = salesConsultant ?? CreateValidSalesConsultant();

        return Domain.SalesConsultant.SalesConsultant.Create(
            lSalesConsultant.Cpf,
            lSalesConsultant.Address,
            name ?? lSalesConsultant.Name,
            lSalesConsultant.Email,
            lSalesConsultant.Landline,
            lSalesConsultant.Mobile
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