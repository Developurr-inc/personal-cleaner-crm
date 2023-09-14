using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Manager;

namespace Orderly.Domain.UnitTests.Manager;

public class ManagerTest
{
    [Theory]
    [MemberData(
        nameof(ManagerGenerator.CreateManagers),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenCreatingManager_GivenValidInput_ShouldInstantiateManager(
        Domain.Manager.Manager manager
    )
    {
        // Arrange
        var cpf = manager.Cpf;
        var address = manager.Address;
        var managerName = manager.ManagerName;
        var nfeEmail = manager.NfeEmail;
        var landline = manager.Landline;
        var mobile = manager.Mobile;


        // Act
        var newManager = Domain.Manager.Manager.Create(
            cpf,
            address,
            managerName,
            nfeEmail,
            landline,
            mobile
        );

        //Assert
        ManagerAssertion.AssertManager(manager, newManager);
    }
    
    
    [Theory]
    [MemberData(
        nameof(ManagerGenerator.CreateInvalidManagerNames),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenCreatingManager_GivenInvalidManagerName_ShouldThrowException(
        string str
    )
    {
        // Arrange
        var manager = ManagerFixture.CreateManager();
        var cpf = manager.Cpf;
        var address = manager.Address;
        var managerName = str;
        var nfeEmail = manager.NfeEmail;
        var landline = manager.Landline;
        var mobile = manager.Mobile;

        void Action()
        {
            _ = Domain.Manager.Manager.Create(
                cpf,
                address,
                managerName,
                nfeEmail,
                landline,
                mobile
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        ManagerAssertion.AssertManagerException(exception!);
    }
}