namespace Orderly.Domain.UnitTests.TestUtils.Address;

public static class AddressFixture
{
    public static Domain.Common.ValueObjects.Address CreateAddress()
    {
        return Domain.Common.ValueObjects.Address.Create(
            Constants.Constants.Address.Street,
            Constants.Constants.Address.Number,
            Constants.Constants.Address.Complement,
            Constants.Constants.Address.ZipCode,
            Constants.Constants.Address.Neighborhood,
            Constants.Constants.Address.City,
            Constants.Constants.Address.State,
            Constants.Constants.Address.Country
        );
    }
}
