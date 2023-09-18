using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Cnpj;

public sealed class CnpjAssertion
{
    public static void AssertCnpj(
        Domain.Common.ValueObjects.Cnpj expected,
        Domain.Common.ValueObjects.Cnpj actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }

    public static void AssertCnpjException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);

        var entityValidationException = (EntityValidationException)exception;

        Assert.NotEmpty(entityValidationException.Errors);
    }
}
