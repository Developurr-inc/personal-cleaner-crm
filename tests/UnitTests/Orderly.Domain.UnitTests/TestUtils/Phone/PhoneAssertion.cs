using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Phone;

public static class PhoneAssertion
{
    public static void AssertPhone(
        Domain.Common.ValueObjects.Phone expected,
        Domain.Common.ValueObjects.Phone actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Value, actual.Value);
    }
    
    
    public static void AssertPhoneException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);
        
        var entityValidationException = (EntityValidationException) exception;
        
        Assert.NotEmpty(entityValidationException.Errors);
    }
}