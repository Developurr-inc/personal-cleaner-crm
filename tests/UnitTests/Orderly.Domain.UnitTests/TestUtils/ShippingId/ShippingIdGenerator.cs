namespace Orderly.Domain.UnitTests.TestUtils.ShippingId;

public class ShippingIdGenerator: BaseGenerator
{
    public static IEnumerable<object[]> CreateShippingIds()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { ShippingIdFixture.CreateShippingId() };
    }
}