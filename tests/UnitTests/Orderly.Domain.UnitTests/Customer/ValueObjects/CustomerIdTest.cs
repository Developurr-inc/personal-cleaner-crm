using Orderly.Domain.Customer.ValueObjects;

namespace Orderly.Domain.UnitTests.Customer.ValueObjects;

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

    [Fact]
    public void GivenNothing_WhenCallingFormat_ThenShouldNotBeEmpty()
    {
        // Arrange
        var customerId = CustomerId.Generate();
        
        // Act
        var id = customerId.Format();
        
        // Assert
        Assert.NotEmpty(id);
    }
}