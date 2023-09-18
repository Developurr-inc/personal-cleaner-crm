using Orderly.Domain.UnitTests.TestUtils.Manager;

namespace Orderly.Domain.UnitTests.Manager;

public class ManagerTest
{
    [Theory]
    [MemberData(nameof(ManagerGenerator.CreateManagers), MemberType = typeof(ManagerGenerator))]
    public void GivenValidInput_WhenCreatingManager_ThenShouldInstantiateManager(
        Domain.Manager.Manager manager
    )
    {
        // Act
        var newManager = ManagerFixture.CreateManager(manager);

        // Assert
        ManagerAssertion.AssertManager(manager, newManager);
    }

    [Theory]
    [MemberData(nameof(ManagerGenerator.CreateInvalidNames), MemberType = typeof(ManagerGenerator))]
    public void GivenInvalidName_WhenCreatingManager_ThenShouldThrowException(string invalidName)
    {
        // Arrange
        void Action()
        {
            _ = ManagerFixture.CreateManager(name: invalidName);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        ManagerAssertion.AssertManagerException(exception!);
    }
}
