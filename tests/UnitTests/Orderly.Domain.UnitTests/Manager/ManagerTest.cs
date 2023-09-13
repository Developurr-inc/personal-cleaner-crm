using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Manager;
using Address = Bogus.DataSets.Address;

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
        nameof(ManagerGenerator.CreateInvalidManager),
        MemberType = typeof(AddressGenerator)
    )]
    public void WhenCreatingManager_GivenInvalidManagerName_ShouldThrowException(
        int str
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
            _ = Manager.Create(
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
    
    
    [Theory]
    [MemberData(
        nameof(ManagerGenerator.UpdateManager),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenUpdatingManager_GivenValidInput_ShouldInstantiateManager(
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
        nameof(ManagerGenerator.UpdateInvalidNameManagers),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenUpdatingManager_GivenInvalidNameManager_ShouldThrowException(
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
            _ = Manager.Create(
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
        ManagerAssertion.AssertAddressException(exception!);
    }
    
    
    [Theory]
    [MemberData(
        nameof(ManagerGenerator.ChangeManagers),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenChangingManager_GivenValidInput_ShouldInstantiateManager(
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
        nameof(ManagerGenerator.ChangeInvalidCpf),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenChangingManager_GivenInvalidCpf_ShouldThrowException(
        Cpf str
    )
    {
        // Arrange
        var manager = ManagerFixture.CreateManager();
        var cpf = str;
        var address = manager.Address;
        var managerName = manager.ManagerName;
        var nfeEmail = manager.NfeEmail;
        var landline = manager.Landline;
        var mobile = manager.Mobile;

        void Action()
        {
            _ = Manager.Create(
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
    
    
    [Theory]
    [MemberData(
        nameof(ManagerGenerator.ChangeInvalidAddress),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenChangingManager_GivenInvalidAddress_ShouldThrowException(
        Address str
    )
    {
        // Arrange
        var manager = ManagerFixture.CreateManager();
        var cpf = manager.Cpf;
        var address = str;
        var managerName = manager.ManagerName;
        var nfeEmail = manager.NfeEmail;
        var landline = manager.Landline;
        var mobile = manager.Mobile;

        void Action()
        {
            _ = Manager.Create(
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
    
    
    [Theory]
    [MemberData(
        nameof(ManagerGenerator.ChangeInvalidNfeEmail),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenChangingManager_GivenInvalidNfeEmail_ShouldThrowException(
        Email str
    )
    {
        // Arrange
        var manager = ManagerFixture.CreateManager();
        var cpf = manager.Cpf;
        var address = manager.Address;
        var managerName = manager.ManagerName;
        var nfeEmail = str;
        var landline = manager.Landline;
        var mobile = manager.Mobile;

        void Action()
        {
            _ = Manager.Create(
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
    
    
    [Theory]
    [MemberData(
        nameof(ManagerGenerator.ChangeInvalidLandline),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenChangingManager_GivenInvalidLandline_ShouldThrowException(
        Phone str
    )
    {
        // Arrange
        var manager = ManagerFixture.CreateManager();
        var cpf = manager.Cpf;
        var address = manager.Address;
        var managerName = manager.ManagerName;
        var nfeEmail = manager.NfeEmail;
        var landline = str;
        var mobile = manager.Mobile;

        void Action()
        {
            _ = Manager.Create(
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
    
    
    [Theory]
    [MemberData(
        nameof(ManagerGenerator.ChangeInvalidMobile),
        MemberType = typeof(ManagerGenerator)
    )]
    public void WhenChangingManager_GivenInvalidMobile_ShouldThrowException(
        Phone str
    )
    {
        // Arrange
        var manager = ManagerFixture.CreateManager();
        var cpf = manager.Cpf;
        var address = manager.Address;
        var managerName = manager.ManagerName;
        var nfeEmail = manager.NfeEmail;
        var landline = manager.Landline;
        var mobile = str;

        void Action()
        {
            _ = Manager.Create(
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