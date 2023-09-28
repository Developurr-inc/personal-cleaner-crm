using Orderly.Domain.Manager.ValueObjects;

namespace Orderly.Domain.UnitTests.Manager.ValueObjects;

public sealed class ManagerIdTest
{
    [Fact]
    public void GivenValidManagerId_WhenGeneratingManagerId_ThenShouldInstantiateManagerId()
    {
        // Act
        var managerId = ManagerId.Generate();

        // Assert
        Assert.NotNull(managerId);
    }
}