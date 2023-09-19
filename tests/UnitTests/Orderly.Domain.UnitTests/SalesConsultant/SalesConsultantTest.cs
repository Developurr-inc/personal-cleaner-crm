using Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

namespace Orderly.Domain.UnitTests.SalesConsultant;

public sealed class SalesConsultantTest
{
    [Theory]
    [MemberData(
        nameof(SalesConsultantGenerator.CreateSalesConsultants),
        MemberType = typeof(SalesConsultantGenerator)
    )]
    public void GivenValidInput_WhenCreatingSalesConsultant_ThenShouldInstantiateSalesConsultant(
        Domain.SalesConsultant.SalesConsultant salesConsultant
    )
    {
        // Act
        var newSalesConsultant = SalesConsultantFixture.CreateSalesConsultant(salesConsultant);

        // Assert
        SalesConsultantAssertion.AssertSalesConsultant(salesConsultant, newSalesConsultant);
    }

    [Theory]
    [MemberData(
        nameof(SalesConsultantGenerator.CreateInvalidNames),
        MemberType = typeof(SalesConsultantGenerator)
    )]
    public void GivenInvalidName_WhenCreatingSalesConsultant_ThenShouldThrowEntityValidationException(
        string invalidName
    )
    {
        // Arrange
        void Action()
        {
            _ = SalesConsultantFixture.CreateSalesConsultant(name: invalidName);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        SalesConsultantAssertion.AssertException(exception!);
    }
}
