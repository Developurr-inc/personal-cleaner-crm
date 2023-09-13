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
    public static Domain.Common.ValueObjects.Address CreateManager()
    {
        var cpf = CpfFixture.CreateValidCpf();
        var address = AddressFixture.CreateAddress();
        var managerName = StringFixture.CreateString();
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
    
    
    public static string CreateShortManagerName()
    {
        return StringFixture.CreateString(
            1,
            ManagerValidator.ManagerNameMinLength - 1
        );
    }
    
    
    public static string CreateLongManagerName()
    {
        return StringFixture.CreateString(
            ManagerValidator.ManagerNameMaxLength + 1,
            1_000
        );
    }
    
    
    public static string CreateManagerName()
    {
        return StringFixture.CreateString(
            ManagerValidator.ManagerNameMinLength,
            ManagerValidator.ManagerNameMaxLength
        );
    }
}