using Orderly.Domain.Manager.ValueObjects;

namespace Orderly.Domain.UnitTests.Manager.ValueObjects;

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
    
    [Fact]
    public void GivenNothing_WhenCallingFormat_ThenShouldNotBeEmpty()
    {
        // Arrange
        var managerId = ManagerId.Generate();
        
        // Act
        var id = managerId.Format();
        
        // Assert
        Assert.NotEmpty(id);
    }
}