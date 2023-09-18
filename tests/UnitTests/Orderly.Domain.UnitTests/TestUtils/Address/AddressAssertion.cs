namespace Orderly.Domain.UnitTests.TestUtils.Address;

public sealed class AddressAssertion : BaseAssertion
{
    public static void AssertAddress(
        Domain.Common.ValueObjects.Address expected,
        Domain.Common.ValueObjects.Address actual
    )
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Street, actual.Street);
        Assert.Equal(expected.Number, actual.Number);
        Assert.Equal(expected.Complement, actual.Complement);
        Assert.Equal(expected.ZipCode, actual.ZipCode);
        Assert.Equal(expected.Neighborhood, actual.Neighborhood);
        Assert.Equal(expected.City, actual.City);
        Assert.Equal(expected.State, actual.State);
        Assert.Equal(expected.Country, actual.Country);
    }
}
