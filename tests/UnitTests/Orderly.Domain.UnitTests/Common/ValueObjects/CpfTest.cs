using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Cpf;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class CpfTest
{
    [Theory]
    [MemberData(nameof(CpfGenerator.CreateCpfs), MemberType = typeof(CpfGenerator))]
    public void GivenValidInput_WhenCreatingCpf_ThenShouldInstantiateCpf(Cpf cpf)
    {
        // Act
        var newCpf = CpfFixture.CreateCpf(cpf);

        // Assert
        CpfAssertion.AssertCpf(cpf, newCpf);
    }

    [Theory]
    [MemberData(nameof(CpfGenerator.CreateInvalidCpfs), MemberType = typeof(CpfGenerator))]
    public void GivenInvalidCpf_WhenCreatingCpf_ThenShouldThrowEntityValidationException(
        string invalidCpf
    )
    {
        // Arrange
        void Action()
        {
            _ = CpfFixture.CreateCpf(value: invalidCpf);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CpfAssertion.AssertException(exception!);
    }
}
