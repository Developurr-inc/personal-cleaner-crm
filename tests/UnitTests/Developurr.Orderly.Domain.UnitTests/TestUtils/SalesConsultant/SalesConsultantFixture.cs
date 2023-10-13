namespace Developurr.Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

public static class SalesConsultantFixture
{
    public static Developurr.Orderly.Domain.SalesConsultant.SalesConsultant CreateSalesConsultant()
    {
        return Developurr.Orderly.Domain.SalesConsultant.SalesConsultant.Create(
            Constants.Constants.Cpf.CpfValue,
            Constants.Constants.Address.Street,
            Constants.Constants.Address.Number,
            Constants.Constants.Address.Complement,
            Constants.Constants.Address.ZipCode,
            Constants.Constants.Address.Neighborhood,
            Constants.Constants.Address.City,
            Constants.Constants.Address.State,
            Constants.Constants.Address.Country,
            Constants.Constants.SalesConsultant.Name,
            Constants.Constants.Email.EmailValue,
            Constants.Constants.Phone.PhoneValue,
            Constants.Constants.Phone.PhoneValue
        );
    }
}