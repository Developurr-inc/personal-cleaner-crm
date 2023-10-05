namespace Orderly.Domain.UnitTests.TestUtils.Order;

public static class OrderFixture
{
    public static Domain.Order.Order CreateCustomer()
    {
        return Domain.Order.Order.Open(
            Constants.Constants.CustomerId.Id,
            Constants.Constants.SalesConsultantId.Id
        );
    }
}