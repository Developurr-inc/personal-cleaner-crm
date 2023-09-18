namespace Orderly.Domain.UnitTests.TestUtils.Order;

public sealed class OrderAssertion : BaseAssertion
{
    public static void AssertOrder(
        Domain.Order.Order expected,
        Domain.Order.Order actual
    )
    {
        Assert.NotNull(actual);
        Assert.NotNull(actual.Id);
        Assert.NotEqual(default, actual.Id.Value);
        Assert.Equal(expected.CustomerId, actual.CustomerId);
        Assert.Equal(expected.SalesConsultantId, actual.SalesConsultantId);
        Assert.Equal(expected.OrderTotal, actual.OrderTotal);
        Assert.NotEqual(default, actual.CreatedAt);
    }
}