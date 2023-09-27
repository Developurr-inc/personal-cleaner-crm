namespace Orderly.Domain.UnitTests.TestUtils.Phone;

public static class PhoneFixture
{
    public static Domain.Common.ValueObjects.Phone CreatePhone()
    {
        return Domain.Common.ValueObjects.Phone.Create(
            Constants.Constants.Phone.PhoneValue 
        );
    }
}