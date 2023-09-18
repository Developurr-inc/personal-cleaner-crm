using Orderly.Domain.Customer.ValueObjects;
using Orderly.Domain.SalesConsultant.ValueObjects;

namespace Orderly.Domain.UnitTests.TestUtils.Order;

public sealed class OrderFixture : BaseFixture
{
    private static Domain.Order.Order CreateValidOrder()
    {
        var customerId = CustomerId.Create();
        var salesConsultantId = SalesConsultantId.Create();
        
        return Domain.Order.Order.Open(customerId, salesConsultantId);
    }
    
    public static Domain.Order.Order CreateOrder(Domain.Order.Order? order = null)
    {
        var lOrder = order ?? CreateValidOrder();
        
        return Domain.Order.Order.Open(lOrder.CustomerId, lOrder.SalesConsultantId);
    }
}
