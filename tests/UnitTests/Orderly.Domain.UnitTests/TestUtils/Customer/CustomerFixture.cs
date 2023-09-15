using Orderly.Domain.Customer.Validators;
using Orderly.Domain.UnitTests.TestUtils.Cnpj;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.Phone;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Customer;

public sealed class CustomerFixture : BaseFixture
{
    private static Domain.Customer.Customer CreateValidCustomer()
    {
        // var salesConsultant = salesConsultantId;
        var cnpj = CnpjFixture.CreateCnpj();
        var billingEmail = EmailFixture.CreateEmail();
        var nfeEmail = EmailFixture.CreateEmail();
        var landline = PhoneFixture.CreatePhone();
        var mobile = PhoneFixture.CreatePhone();

        var corporateName = StringFixture.CreateString(
            CustomerValidator.CorporateNameMinLength,
            CustomerValidator.CorporateNameMaxLength
        );
        var taxId = StringFixture.CreateString(
            CustomerValidator.TaxIdMinLength,
            CustomerValidator.TaxIdMaxLength
        );
        var tradeName = StringFixture.CreateString(
            CustomerValidator.TradeNameMinLength,
            CustomerValidator.TradeNameMaxLength
        );
        var segment = StringFixture.CreateString(
            CustomerValidator.SegmentMinLength,
            CustomerValidator.SegmentMaxLength
        );
        var observation = StringFixture.CreateString(max: CustomerValidator.CorporateNameMaxLength);

        return Domain.Customer.Customer.Create(
            // salesConsultant,
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
            // customer.SalesConsultant,
            lCustomer.Cnpj,
            corporateName ?? lCustomer.CorporateName,
            taxId ?? lCustomer.TaxId,
            tradeName ?? lCustomer.TradeName,
            segment ?? lCustomer.Segment,
            lCustomer.BillingEmail,
            lCustomer.NfeEmail,
            lCustomer.Landline,
            lCustomer.Mobile,
            observation ?? lCustomer.Observation
        );
    }

    public static string CreateShortCorporateName()
    {
        return StringFixture.CreateString(1, CustomerValidator.CorporateNameMinLength - 1);
    }

    public static string CreateLongCorporateName()
    {
        return StringFixture.CreateString(CustomerValidator.CorporateNameMaxLength + 1, 1_000);
    }

    public static string CreateShortTaxId()
    {
        return StringFixture.CreateString(1, CustomerValidator.TaxIdMinLength - 1);
    }

    public static string CreateLongTaxId()
    {
        return StringFixture.CreateString(CustomerValidator.TaxIdMaxLength + 1, 1_000);
    }

    public static string CreateShortTradeName()
    {
        return StringFixture.CreateString(1, CustomerValidator.TradeNameMinLength - 1);
    }

    public static string CreateLongTradeName()
    {
        return StringFixture.CreateString(CustomerValidator.TradeNameMaxLength + 1, 1_000);
    }

    public static string CreateShortSegment()
    {
        return StringFixture.CreateString(1, CustomerValidator.SegmentMinLength - 1);
    }

    public static string CreateLongSegment()
    {
        return StringFixture.CreateString(CustomerValidator.SegmentMaxLength + 1, 1_000);
    }

    public static string CreateLongObservation()
    {
        return StringFixture.CreateString(CustomerValidator.ObservationMaxLength + 1, 20_000);
    }
}
