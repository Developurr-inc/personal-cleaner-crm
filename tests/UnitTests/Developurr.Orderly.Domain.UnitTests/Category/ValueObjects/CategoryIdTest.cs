using Developurr.Orderly.Domain.Category.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Category.ValueObjects;

public sealed class CategoryIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingCustomerId_ThenShouldInstantiateCustomerId()
    {
        // Act
        var categoryId = CategoryId.Generate();

        // Assert
        Assert.NotNull(categoryId);
    }
}
