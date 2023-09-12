using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Cpf;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class CpfTest
{
    [Theory]
    [MemberData(
        nameof(CpfGenerator.CreateCpfs),
        MemberType = typeof(CpfGenerator)
    )]
    public void WhenCreatingCpf_GivenValidInput_ShouldInstantiateCpf(
        Cpf cpf
    )
    {
        // Arrange
        var cpfValue = cpf.Value;

        // Act
        var newCpf = Cpf.Create(cpfValue);

        // Assert
        CpfAssertion.AssertCpf(cpf, newCpf);
    }


    [Theory]
    [MemberData(
        nameof(CpfGenerator.CreateInvalidCpfs),
        MemberType = typeof(CpfGenerator)
    )]
    public void WhenCreatingCpf_GivenInvalidInput_ShouldThrowException(
        string cpfValue)
    {
        // Arrange
        void Action()
        {
            _ = Cpf.Create(cpfValue);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        CpfAssertion.AssertCpfException(exception!);
    }
}