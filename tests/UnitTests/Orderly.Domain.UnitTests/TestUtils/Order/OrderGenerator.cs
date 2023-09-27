namespace Orderly.Domain.UnitTests.TestUtils.Order;

public sealed class OrderGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateOrders()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                OrderFixture.CreateOrder()
            };
    }
}