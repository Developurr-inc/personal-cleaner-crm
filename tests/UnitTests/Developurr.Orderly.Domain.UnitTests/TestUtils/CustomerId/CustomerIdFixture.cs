namespace Developurr.Orderly.Domain.UnitTests.TestUtils.CustomerId;

public class CustomerIdFixture
{
    public static Domain.Customer.ValueObjects.CustomerId GenerateId()
    {
        return Domain.Customer.ValueObjects.CustomerId.Generate();
    }
}
