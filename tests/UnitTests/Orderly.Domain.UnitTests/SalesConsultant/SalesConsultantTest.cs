using Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

namespace Orderly.Domain.UnitTests.SalesConsultant;

public class SalesConsultantTest
{
    [Theory]
    [MemberData(
        nameof(SalesConsultantGenerator.CreateSalesConsultants),
        MemberType = typeof(SalesConsultantGenerator)
    )]
    public void WhenCreatingSalesConsultant_GivenValidInput_ShouldInstantiateSalesConsultant(
        Domain.SalesConsultant.SalesConsultant salesConsultant
    )
    {
        // Arrange
        var cpf = salesConsultant.Cpf;
        var address = salesConsultant.Address;
        var managerName = salesConsultant.Name;
        var email = salesConsultant.Email;
        var landline = salesConsultant.Landline;
        var mobile = salesConsultant.Mobile;

        // Act
        var newSalesConsultant = Domain.SalesConsultant.SalesConsultant.Create(
            cpf,
            address,
            managerName,
            email,
            landline,
            mobile
        );

        // Assert
        SalesConsultantAssertion.AssertSalesConsultant(salesConsultant, newSalesConsultant);
    }


    [Theory]
    [MemberData(
        nameof(SalesConsultantGenerator.CreateInvalidNames),
        MemberType = typeof(SalesConsultantGenerator)
    )]
    public void WhenCreatingSalesConsultant_GivenInvalidName_ShouldThrowException(
        string invalidName
    )
    {
        // Arrange
        var manager = SalesConsultantFixture.CreateSalesConsultant();
        var cpf = manager.Cpf;
        var address = manager.Address;
        var name = invalidName;
        var email = manager.Email;
        var landline = manager.Landline;
        var mobile = manager.Mobile;

        void Action()
        {
            _ = Domain.SalesConsultant.SalesConsultant.Create(
                cpf,
                address,
                name,
                email,
                landline,
                mobile
            );
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        SalesConsultantAssertion.AssertSalesConsultantException(exception!);
    }
}