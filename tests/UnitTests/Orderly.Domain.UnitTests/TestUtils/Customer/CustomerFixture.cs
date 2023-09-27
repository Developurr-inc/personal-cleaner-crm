using Orderly.Domain.Customer.Validators;
using Orderly.Domain.SalesConsultant.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Cnpj;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.Phone;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Customer;

public sealed class CustomerFixture : BaseFixture
{
    private static Domain.Customer.Customer CreateValidCustomer()
    {
        var salesConsultant = SalesConsultantId.Generate();
        var cnpj = CnpjFixture.CreateCnpj().Format();
        var billingEmail = EmailFixture.CreateEmail().Format();
        var nfeEmail = EmailFixture.CreateEmail().Format();
        var landline = PhoneFixture.CreatePhone().Value;
        var mobile = PhoneFixture.CreatePhone().Value;

        var corporateName = StringFixture.CreateString(
            CustomerValidatorConfig.CorporateNameMinLength,
            CustomerValidatorConfig.CorporateNameMaxLength
        );
        var taxId = StringFixture.CreateString(
            CustomerValidatorConfig.TaxIdMinLength,
            CustomerValidatorConfig.TaxIdMaxLength
        );
        var tradeName = StringFixture.CreateString(
            CustomerValidatorConfig.TradeNameMinLength,
            CustomerValidatorConfig.TradeNameMaxLength
        );
        var segment = StringFixture.CreateString(
            CustomerValidatorConfig.SegmentMinLength,
            CustomerValidatorConfig.SegmentMaxLength
        );
        var observation = StringFixture.CreateString(
            max: CustomerValidatorConfig.CorporateNameMaxLength
        );

        return Domain.Customer.Customer.Create(
            salesConsultant,
            cnpj,
            corporateName,
            taxId,
            tradeName,
            segment,
            billingEmail,
            nfeEmail,
            landline,
            mobile,
            observation
        );
    }

    public static Domain.Customer.Customer CreateCustomer(
        Domain.Customer.Customer? customer = null,
        string? corporateName = null,
        string? taxId = null,
        string? tradeName = null,
        string? segment = null,
        string? observation = null
    )
    {
        var lCustomer = customer ?? CreateValidCustomer();

        return Domain.Customer.Customer.Create(
            lCustomer.SalesConsultant,
            lCustomer.Cnpj.Format(),
            corporateName ?? lCustomer.CorporateName,
            taxId ?? lCustomer.TaxId,
            tradeName ?? lCustomer.TradeName,
            segment ?? lCustomer.Segment,
            lCustomer.BillingEmail?.Format(),
            lCustomer.NfeEmail.Format(),
            lCustomer.Landline?.Value,
            lCustomer.Mobile?.Value,
            observation ?? lCustomer.Observation
        );
    }

    public static string CreateShortCorporateName()
    {
        return StringFixture.CreateString(1, CustomerValidatorConfig.CorporateNameMinLength - 1);
    }

    public static string CreateLongCorporateName()
    {
        return StringFixture.CreateString(
            CustomerValidatorConfig.CorporateNameMaxLength + 1,
            1_000
        );
    }

    public static string CreateShortTaxId()
    {
        return StringFixture.CreateString(1, CustomerValidatorConfig.TaxIdMinLength - 1);
    }

    public static string CreateLongTaxId()
    {
        return StringFixture.CreateString(CustomerValidatorConfig.TaxIdMaxLength + 1, 1_000);
    }

    public static string CreateShortTradeName()
    {
        return StringFixture.CreateString(1, CustomerValidatorConfig.TradeNameMinLength - 1);
    }

    public static string CreateLongTradeName()
    {
        return StringFixture.CreateString(CustomerValidatorConfig.TradeNameMaxLength + 1, 1_000);
    }

    public static string CreateShortSegment()
    {
        return StringFixture.CreateString(1, CustomerValidatorConfig.SegmentMinLength - 1);
    }

    public static string CreateLongSegment()
    {
        return StringFixture.CreateString(CustomerValidatorConfig.SegmentMaxLength + 1, 1_000);
    }

    public static string CreateLongObservation()
    {
        return StringFixture.CreateString(CustomerValidatorConfig.ObservationMaxLength + 1, 20_000);
    }
}
