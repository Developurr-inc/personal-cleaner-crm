using Developurr.Orderly.Domain.Manager.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Manager.ValueObjects;

public sealed class ManagerIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingManagerId_ThenShouldInstantiateManagerId()
    {
        // Act
        var managerId = ManagerId.Generate();

        // Assert
        Assert.NotNull(managerId);
    }
}
