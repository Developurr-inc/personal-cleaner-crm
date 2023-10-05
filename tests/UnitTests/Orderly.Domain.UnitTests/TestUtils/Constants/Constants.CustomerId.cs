using Orderly.Domain.SalesConsultant.ValueObjects;

namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class CustomerId
    {
        public static Domain.Customer.ValueObjects.CustomerId Id = Domain.Customer.ValueObjects.CustomerId.Generate();
    }
}