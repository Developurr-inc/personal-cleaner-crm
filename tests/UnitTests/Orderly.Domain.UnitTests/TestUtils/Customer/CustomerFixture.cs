namespace Orderly.Domain.UnitTests.TestUtils.Customer;

public static class CustomerFixture
{
    public static Domain.Customer.Customer CreateCustomer()
    {
        return Domain.Customer.Customer.Create(
            Constants.Constants.SalesConsultantId.Id,
            Constants.Constants.Cnpj.CnpjValue,
            Constants.Constants.Customer.CorporateName,
            Constants.Constants.Customer.TaxId,
            Constants.Constants.Customer.TradeName,
            Constants.Constants.Customer.Segment,
            Constants.Constants.Email.EmailValue,
            Constants.Constants.Email.EmailValue,
            Constants.Constants.Phone.PhoneValue,
            Constants.Constants.Phone.PhoneValue,
            Constants.Constants.Customer.Observation
        );
    }
}