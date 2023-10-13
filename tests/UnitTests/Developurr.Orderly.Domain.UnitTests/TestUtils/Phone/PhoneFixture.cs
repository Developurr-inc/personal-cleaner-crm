namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Phone;

public static class PhoneFixture
{
    public static Developurr.Orderly.Domain.Shared.ValueObjects.Phone CreatePhone()
    {
        return Developurr.Orderly.Domain.Shared.ValueObjects.Phone.Create(
            Constants.Constants.Phone.PhoneValue 
        );
    }
}