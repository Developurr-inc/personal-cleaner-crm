using Developurr.Orderly.Domain.Customer.Validators;
using Developurr.Orderly.Domain.Customer.ValueObjects;
using Developurr.Orderly.Domain.Order.ValueObjects;
using Developurr.Orderly.Domain.SalesConsultant.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.Customer;

public sealed class Customer : Entity<CustomerId>, IAggregateRoot
{
    private readonly List<OrderId> _orders;
    public SalesConsultantId SalesConsultant { get; private set; }
    public Cnpj Cnpj { get; }
    public string CorporateName { get; private set; }
    public string TaxId { get; private set; }
    public string TradeName { get; private set; }
    public string Segment { get; private set; }
    public Email? BillingEmail { get; private set; }
    public Email NfeEmail { get; private set; }
    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }
    public string Observation { get; private set; }

    private Customer(
        CustomerId customerId,
        SalesConsultantId salesConsultantId,
        Cnpj cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment,
        Email? billingEmail,
        Email nfeEmail,
        Phone? landline,
        Phone? mobile,
        string observation
    )
        : base(customerId)
    {
        _orders = new List<OrderId>();
        SalesConsultant = salesConsultantId;
        Cnpj = cnpj;
        CorporateName = corporateName;
        TaxId = taxId;
        TradeName = tradeName;
        Segment = segment;
        BillingEmail = billingEmail;
        NfeEmail = nfeEmail;
        Landline = landline;
        Mobile = mobile;
        Observation = observation;
    }

    public static Customer Create(
        SalesConsultantId salesConsultantId,
        string cnpjValue,
        string corporateName,
        string taxId,
        string tradeName,
        string segment,
        string? billingEmailValue,
        string nfeEmailValue,
        string? landlineValue,
        string? mobileValue,
        string observation
    )
    {
        var customerId = CustomerId.Generate();
        var cnpj = Cnpj.Create(cnpjValue);
        var corporateNameTrimmed = corporateName.Trim();
        var taxIdTrimmed = taxId.Trim();
        var tradeNameTrimmed = tradeName.Trim();
        var segmentTrimmed = segment.Trim();
        var billingEmail = billingEmailValue == null ? null : Email.Create(billingEmailValue);
        var nfeEmail = Email.Create(nfeEmailValue);
        var landline = landlineValue == null ? null : Phone.Create(landlineValue);
        var mobile = mobileValue == null ? null : Phone.Create(mobileValue);
        var observationTrimmed = observation.Trim();

        Validate(
            corporateNameTrimmed,
            taxIdTrimmed,
            tradeNameTrimmed,
            segmentTrimmed,
            observationTrimmed
        );

        return new Customer(
            customerId,
            salesConsultantId,
            cnpj,
            corporateNameTrimmed,
            taxIdTrimmed,
            tradeNameTrimmed,
            segmentTrimmed,
            billingEmail,
            nfeEmail,
            landline,
            mobile,
            observationTrimmed
        );
    }

    private static void Validate(
        string corporateName,
        string taxId,
        string tradeName,
        string segment,
        string observation
    )
    {
        var customerValidator = new CustomerValidator(
            corporateName,
            taxId,
            tradeName,
            segment,
            observation
        );
        customerValidator.Validate();
    }
}
