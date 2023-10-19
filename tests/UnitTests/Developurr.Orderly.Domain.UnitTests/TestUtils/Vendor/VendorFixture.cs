namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Vendor;

public static class VendorFixture
{
    public static Domain.Vendor.Vendor CreateVendor()
    {
        return Domain.Vendor.Vendor.Create(
            Constants.Constants.Cpf.CpfValue,
            Constants.Constants.Address.Street,
            Constants.Constants.Address.Number,
            Constants.Constants.Address.Complement,
            Constants.Constants.Address.ZipCode,
            Constants.Constants.Address.Neighborhood,
            Constants.Constants.Address.City,
            Constants.Constants.Address.State,
            Constants.Constants.Address.Country,
            Constants.Constants.Vendor.Name,
            Constants.Constants.Email.EmailValue,
            Constants.Constants.Phone.PhoneValue,
            Constants.Constants.Phone.PhoneValue
        );
    }
}