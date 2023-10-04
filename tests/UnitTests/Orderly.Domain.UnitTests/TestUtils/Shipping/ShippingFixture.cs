namespace Orderly.Domain.UnitTests.TestUtils.Shipping;

public static class ShippingFixture
{
    public static Domain.Shipping.Shipping CreateShipping()
    {
        return Domain.Shipping.Shipping.Create(
            Constants.Constants.Cnpj.CnpjValue,
            Constants.Constants.Shipping.CorporateName,
            Constants.Constants.Shipping.TaxId,
            Constants.Constants.Shipping.TradeName,
            Constants.Constants.Shipping.Segment
        );
    }
}