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
    public NonEmptyText CorporateName { get; private set; }
    public NonEmptyText TaxId { get; private set; }
    public NonEmptyText TradeName { get; private set; }
    public NonEmptyText Segment { get; private set; }
    public Email? BillingEmail { get; private set; }
    public Email NfeEmail { get; private set; }
    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }
    public NonEmptyText Observation { get; private set; }
    public ActiveStatus Active { get; private set; }

    private Customer(
        CustomerId customerId,
        SalesConsultantId salesConsultantId,
        Cnpj cnpj,
        NonEmptyText corporateName,
        NonEmptyText taxId,
        NonEmptyText tradeName,
        NonEmptyText segment,
        Email? billingEmail,
        Email nfeEmail,
        Phone? landline,
        Phone? mobile,
        NonEmptyText observation,
        ActiveStatus active
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
        Active = active;
    }
    
    public void Deactivate()
    {
        if (Active.IsActive)
            Active = ActiveStatus.Inactive;
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
        var active = ActiveStatus.Active;

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
            observationTrimmed,
            active
        );
    }
    
}
