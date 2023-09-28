using Orderly.Domain.Customer.ValueObjects;

namespace Orderly.Domain.UnitTests.Customer.ValueObjects;

public sealed class CustomerIdTest
{
    [Fact]
    public void GivenValidCustomerId_WhenGeneratingCustomerId_ThenShouldInstantiateCustomerId()
    {
        // Act
        var customerId = CustomerId.Generate();

        // Assert
        Assert.NotNull(customerId);
    }
}