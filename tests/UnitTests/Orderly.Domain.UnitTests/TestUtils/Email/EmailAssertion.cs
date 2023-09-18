using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Email;

public static class EmailAssertion
{
    public static void AssertEmail(
        Domain.Common.ValueObjects.Email expected,
        Domain.Common.ValueObjects.Email actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }

    public static void AssertEmailException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);

        var entityValidationException = (EntityValidationException)exception;

        Assert.NotEmpty(entityValidationException.Errors);
    }
}
