using Developurr.Orderly.Domain.Exceptions;

namespace Developurr.Orderly.Domain.UnitTests.TestUtils;

public abstract class BaseAssertion
{
    private const string ErrorMessage = "There are validation errors.";

    public static void AssertException(Exception exception)
    {
        Assert.NotNull(exception);
        var entityValidationException = Assert.IsType<EntityValidationException>(exception);

        Assert.Equal(ErrorMessage, entityValidationException.Message);
        Assert.NotEmpty(entityValidationException.Errors);
    }
}
