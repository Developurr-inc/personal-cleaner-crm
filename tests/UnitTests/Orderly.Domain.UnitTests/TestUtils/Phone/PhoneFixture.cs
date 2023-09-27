using Orderly.Domain.Common.ValueObjects.Validators;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Phone;

public sealed class PhoneFixture : BaseFixture
{
    private static Domain.Common.ValueObjects.Phone CreateValidPhone()
    {
        var phone = Faker.Phone.PhoneNumber();

        return Domain.Common.ValueObjects.Phone.Create(phone);
    }

    public static Domain.Common.ValueObjects.Phone CreatePhone(
        Domain.Common.ValueObjects.Phone? phone = null,
        string? value = null
    )
    {
        var lPhone = phone ?? CreateValidPhone();

        return Domain.Common.ValueObjects.Phone.Create(value ?? lPhone.Value);
    }

    public static string CreateInvalidPhoneNumber()
    {
        return StringFixture.CreateString(
            PhoneValidatorConfig.PhoneMinLength,
            PhoneValidatorConfig.PhoneMaxLength
        );
    }

    public static string CreateShortPhoneNumber()
    {
        return StringFixture.CreateString(1, PhoneValidatorConfig.PhoneMinLength - 1);
    }

    public static string CreateLongPhoneNumber()
    {
        return StringFixture.CreateString(PhoneValidatorConfig.PhoneMaxLength + 1, 1_000);
    }
}
