using Orderly.Domain.Exceptions;

namespace Orderly.Domain.UnitTests.TestUtils.Manager;

public class ManagerAssertion
{
    public static void AssertManager(
        Domain.Manager.Manager expected,
        Domain.Manager.Manager actual
    )
    {
        Assert.NotNull(actual);
        Assert.NotNull(actual.Id);
        Assert.NotEqual(actual.Id.Value, default);
        Assert.Equal(expected.Cpf, actual.Cpf);
        Assert.Equal(expected.Address, actual.Address);
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Email, actual.Email);
        Assert.Equal(expected.Landline, actual.Landline);
        Assert.Equal(expected.Mobile, actual.Mobile);
        Assert.NotEqual(actual.CreatedAt, default);
    }
    
    
    public static void AssertManagerException(Exception exception)
    {
        Assert.NotNull(exception);
        Assert.IsType<EntityValidationException>(exception);
    }
}