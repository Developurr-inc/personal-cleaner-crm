using Orderly.Domain.Common.ValueObjects.Validators;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Phone;

public sealed class PhoneFixture : BaseFixture
{
    public static Domain.Common.ValueObjects.Phone CreatePhone()
    {
        var phone = Faker.Phone.PhoneNumber();

        return Domain.Common.ValueObjects.Phone.Create(phone);
    }
    
    
    public static string CreateInvalidPhoneNumber()
    {
        return StringFixture.CreateString(
            PhoneValidator.PhoneMinLength,
            PhoneValidator.PhoneMaxLength
        );
    }
    
    
    public static string CreateShortPhoneNumber()
    {
        return StringFixture.CreateString(
            1,
            PhoneValidator.PhoneMinLength - 1
        );
    }
    
    
    public static string CreateLongPhoneNumber()
    {
        return StringFixture.CreateString(
            PhoneValidator.PhoneMaxLength + 1,
            1_000
        );
    }
}