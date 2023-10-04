namespace Orderly.Domain.UnitTests.TestUtils.Manager;

public sealed class ManagerAssertion : BaseAssertion
{
    public static void AssertManager(Domain.Manager.Manager expected, Domain.Manager.Manager actual)
    {
        Assert.NotNull(actual); 
        Assert.NotNull(actual.Id);
        Assert.Equal(expected.Cpf, actual.Cpf);
        Assert.Equal(expected.Address, actual.Address);
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Email, actual.Email);
        Assert.Equal(expected.Landline, actual.Landline);
        Assert.Equal(expected.Mobile, actual.Mobile);
    }
}
