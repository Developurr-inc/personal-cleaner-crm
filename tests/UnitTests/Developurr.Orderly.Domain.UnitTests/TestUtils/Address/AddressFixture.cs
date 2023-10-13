namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Address;

public static class AddressFixture
{
    public static Developurr.Orderly.Domain.Shared.ValueObjects.Address CreateAddress()
    {
        return Developurr.Orderly.Domain.Shared.ValueObjects.Address.Create(
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
