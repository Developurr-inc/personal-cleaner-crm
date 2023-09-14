using Bogus.Extensions.Brazil;
using Orderly.Domain.Manager.Validators;
using Orderly.Domain.UnitTests.TestUtils.Address;
using Orderly.Domain.UnitTests.TestUtils.Cpf;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.Phone;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Manager;

public class ManagerFixture : BaseFixture
{
    public static Domain.Manager.Manager CreateManager()
    {
        var cpf = CpfFixture.CreateValidCpf();
        var address = AddressFixture.CreateAddress();
        var managerName = StringFixture.CreateString(
            ManagerValidator.NameMinLength,
            ManagerValidator.NameMaxLength
        );
        var nfeEmail = EmailFixture.CreateEmail();
        var landline = PhoneFixture.CreatePhone();
        var mobile = PhoneFixture.CreatePhone();

        return Domain.Manager.Manager.Create(
            cpf,
            address,
            managerName,
            nfeEmail,
            landline,
            mobile
        );
    }
    
    
    public static string CreateShortName()
    {
        return StringFixture.CreateString(
            1,
            ManagerValidator.NameMinLength - 1
        );
    }
    
    
    public static string CreateLongName()
    {
        return StringFixture.CreateString(
            ManagerValidator.NameMaxLength + 1,
            1_000
        );
    }
}