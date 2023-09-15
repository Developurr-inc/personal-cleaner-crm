namespace Orderly.Domain.UnitTests.TestUtils.Phone;

public sealed class PhoneGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreatePhones()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                PhoneFixture.CreatePhone()
            };
    }


    public static IEnumerable<object[]> CreateInvalidPhones()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                PhoneFixture.CreateInvalidPhoneNumber()
            };

            yield return new object[]
            {
                PhoneFixture.CreateShortPhoneNumber()
            };

            yield return new object[]
            {
                PhoneFixture.CreateLongPhoneNumber()
            };
        }
    }
}