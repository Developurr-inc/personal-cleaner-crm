using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Cnpj;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class CnpjTest
{
    [Theory]
    [MemberData(
        nameof(CnpjGenerator.CreateCnpjs),
        MemberType = typeof(CnpjGenerator)
    )]
    public void WhenCreatingCnpj_GivenValidInput_ShouldInstantiateCnpj(
        Cnpj cnpj
    )
    {
        // Arrange
        var cnpjValue = cnpj.Value;

        // Act
        var newCnpj = Cnpj.Create(cnpjValue);

        // Assert
        CnpjAssertion.AssertCnpj(cnpj, newCnpj);
    }


    [Theory]
    [MemberData(
        nameof(CnpjGenerator.CreateInvalidCnpjValues),
        MemberType = typeof(CnpjGenerator)
    )]
    public void WhenCreatingCnpj_GivenInvalidCnpj_ShouldThrowException(
        string cnpjValue
    )
    {
        // Arrange
        void Action()
        {
            _ = Cnpj.Create(cnpjValue);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CnpjAssertion.AssertCnpjException(exception!);
    }
}