using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Cpf;

public static class CpfAssertion
{
    public static void AssertCpf(
        Domain.Common.ValueObjects.Cpf expected,
        Domain.Common.ValueObjects.Cpf actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
    
    
    public static void AssertCpfException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);

        var entityValidationException = (EntityValidationException)exception;
        
        Assert.NotEmpty(entityValidationException.Errors);
    }
}
