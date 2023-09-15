using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Customer.Validators;
using Orderly.Domain.Customer.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Customer;

public sealed class Customer : Entity<CustomerId>, IAggregateRoot
{
    // public List<OrderId> Orders { get; private set; };
    // public SalesConsultantId SalesConsultant { get; private set; };

    public Cnpj Cnpj { get; private set; }
    public string CorporateName { get; private set; }
    public string TaxId { get; private set; }
    public string TradeName { get; private set; }
    public string Segment { get; private set; }

    public Email? BillingEmail { get; private set; }
    public Email NfeEmail { get; private set; }

    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }

    public string Observation { get; private set; }

    public DateTime CreatedAt { get; }

    private Customer(
        // SalesConsultantId salesConsultantId,
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
        : base(CustomerId.Create())
    {
        // Orders = new();
        // SalesConsultant = salesConsultantId;
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
        CreatedAt = DateTime.Now;
    }

    public static Customer Create(
        // SalesConsultantId salesConsultantId,
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
    {
        var corporateNameTrimmed = corporateName.Trim();
        var taxIdTrimmed = taxId.Trim();
        var tradeNameTrimmed = tradeName.Trim();
        var segmentTrimmed = segment.Trim();
        var observationTrimmed = observation.Trim();

        Validate(
            corporateNameTrimmed,
            taxIdTrimmed,
            tradeNameTrimmed,
            segmentTrimmed,
            observationTrimmed
        );

        return new Customer(
            // salesConsultantId,
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
