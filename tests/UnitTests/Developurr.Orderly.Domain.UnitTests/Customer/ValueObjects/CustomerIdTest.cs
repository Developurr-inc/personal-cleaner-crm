using Developurr.Orderly.Domain.Customer.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Customer.ValueObjects;

public sealed class CustomerIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingCustomerId_ThenShouldInstantiateCustomerId()
    {
        // Act
        var customerId = CustomerId.Generate();

        // Assert
        Assert.NotNull(customerId);
    }
}
