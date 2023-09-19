using Orderly.Domain.Customer.Validators;
using Orderly.Domain.Shipping.Validators;
using Orderly.Domain.UnitTests.TestUtils.Cnpj;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Shipping;

public sealed class ShippingFixture : BaseFixture
{
    private static Domain.Shipping.Shipping CreateValidShipping()
    {
        // var salesConsultant = salesConsultantId;
        var cnpj = CnpjFixture.CreateCnpj();
        
        var corporateName = StringFixture.CreateString(
            ShippingValidator.CorporateNameMinLength,
            ShippingValidator.CorporateNameMaxLength
        );
        var taxId = StringFixture.CreateString(
            ShippingValidator.TaxIdMinLength,
            ShippingValidator.TaxIdMaxLength
        );
        var tradeName = StringFixture.CreateString(
            ShippingValidator.TradeNameMinLength,
            ShippingValidator.TradeNameMaxLength
        );
        var segment = StringFixture.CreateString(
            ShippingValidator.SegmentMinLength,
            ShippingValidator.SegmentMaxLength
        );

        return Domain.Shipping.Shipping.Create(
            // salesConsultant,
            cnpj,
            corporateName,
            taxId,
            tradeName,
            segment
        );
    }
    
    
    public static Domain.Shipping.Shipping CreateShipping(
        Domain.Shipping.Shipping? shipping = null,
        string? corporateName = null,
        string? taxId = null,
        string? tradeName = null,
        string? segment = null
    )
    {
        var lShipping = shipping ?? CreateValidShipping();

        return Domain.Shipping.Shipping.Create(
            // customer.SalesConsultant,
            lShipping.Cnpj,
            corporateName ?? lShipping.CorporateName,
            taxId ?? lShipping.TaxId,
            tradeName ?? lShipping.TradeName,
            segment ?? lShipping.Segment
        );
    }
    
    
    public static string CreateShortCorporateName()
    {
        return StringFixture.CreateString(1, ShippingValidator.CorporateNameMinLength - 1);
    }

    public static string CreateLongCorporateName()
    {
        return StringFixture.CreateString(ShippingValidator.CorporateNameMaxLength + 1, 1_000);
    }

    public static string CreateShortTaxId()
    {
        return StringFixture.CreateString(1, ShippingValidator.TaxIdMinLength - 1);
    }

    public static string CreateLongTaxId()
    {
        return StringFixture.CreateString(ShippingValidator.TaxIdMaxLength + 1, 1_000);
    }

    public static string CreateShortTradeName()
    {
        return StringFixture.CreateString(1, ShippingValidator.TradeNameMinLength - 1);
    }

    public static string CreateLongTradeName()
    {
        return StringFixture.CreateString(ShippingValidator.TradeNameMaxLength + 1, 1_000);
    }

    public static string CreateShortSegment()
    {
        return StringFixture.CreateString(1, ShippingValidator.SegmentMinLength - 1);
    }

    public static string CreateLongSegment()
    {
        return StringFixture.CreateString(ShippingValidator.SegmentMaxLength + 1, 1_000);
    }
}