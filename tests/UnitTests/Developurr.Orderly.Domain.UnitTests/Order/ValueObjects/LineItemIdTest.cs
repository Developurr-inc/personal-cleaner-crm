using Developurr.Orderly.Domain.Order.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Order.ValueObjects;

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
}
