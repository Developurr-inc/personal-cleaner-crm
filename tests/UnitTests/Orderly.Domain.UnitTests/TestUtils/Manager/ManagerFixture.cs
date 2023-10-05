namespace Orderly.Domain.UnitTests.TestUtils.Manager;

public sealed class ManagerFixture
{
    private static Domain.Manager.Manager CreateManager()
    {
        return Domain.Manager.Manager.Create(
            Constants.Constants.Cpf.CpfValue,
            Constants.Constants.Address.Street,
            Constants.Constants.Address.Number,
            Constants.Constants.Address.Complement,
            Constants.Constants.Address.ZipCode,
            Constants.Constants.Address.Neighborhood,
            Constants.Constants.Address.City,
            Constants.Constants.Address.State,
            Constants.Constants.Address.Country,
            Constants.Constants.Manager.Name,
            Constants.Constants.Email.EmailValue,
            Constants.Constants.Phone.PhoneValue,
            Constants.Constants.Phone.PhoneValue
        );
    }
}
