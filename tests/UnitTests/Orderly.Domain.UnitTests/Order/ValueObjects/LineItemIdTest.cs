using Orderly.Domain.Order.ValueObjects;

namespace Orderly.Domain.UnitTests.Order.ValueObjects;

public sealed class LineItemIdTest
{
    [Fact]
    public void GivenValidLineItemId_WhenGeneratingLineItemId_ThenShouldInstantiateLineItemId()
    {
        // Act
        var lineItemId = LineItemId.Generate();

        // Assert
        Assert.NotNull(lineItemId);
    }
}