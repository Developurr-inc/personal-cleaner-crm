namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Order;

public static class OrderFixture
{
    public static Developurr.Orderly.Domain.Order.Order CreateOrder()
    {
        return Developurr.Orderly.Domain.Order.Order.Open(
            Constants.Constants.CustomerId.Id,
            Constants.Constants.SalesConsultantId.Id
        );
    }
}