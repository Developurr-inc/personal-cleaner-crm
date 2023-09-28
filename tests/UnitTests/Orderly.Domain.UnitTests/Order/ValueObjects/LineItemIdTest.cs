using Orderly.Domain.Order.ValueObjects;

namespace Orderly.Domain.UnitTests.Order.ValueObjects;

public sealed class LineItemIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingLineItemId_ThenShouldInstantiateLineItemId()
    {
        // Act
        var lineItemId = LineItemId.Generate();

        // Assert
        Assert.NotNull(lineItemId);
    }
    
    [Fact]
    public void GivenNothing_WhenCallingFormat_ThenShouldNotBeEmpty()
    {
        // Arrange
        var lineItemId = LineItemId.Generate();
        
        // Act
        var id = lineItemId.Format();
        
        // Assert
        Assert.NotEmpty(id);
    }
}