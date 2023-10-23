using Developurr.Orderly.Domain.UnitTests.TestUtils.CustomerId;
using Developurr.Orderly.Domain.UnitTests.TestUtils.VendorId;

namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Order;

public static class OrderFixture
{
    public static Developurr.Orderly.Domain.Order.Order CreateOrder()
    {
        var customerId = CustomerIdFixture.GenerateId();
        var vendorId = VendorIdFixture.GenerateId();

        return Developurr.Orderly.Domain.Order.Order.Open(customerId, vendorId);
    }
}
