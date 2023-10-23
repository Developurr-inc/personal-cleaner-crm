using Developurr.Orderly.Domain.Customer.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.Vendor.ValueObjects;

namespace Developurr.Orderly.Domain.Customer;

public sealed class Customer : Entity<CustomerId>, IAggregateRoot
{
    // private readonly List<OrderId> _orders;
    public VendorId Vendor { get; private set; }
    public Cnpj Cnpj { get; }
    public NonEmptyText CorporateName { get; private set; }
    public NonEmptyText TaxId { get; private set; }
    public NonEmptyText TradeName { get; private set; }
    public NonEmptyText Segment { get; private set; }
    public Email? BillingEmail { get; private set; }
    public Email NfeEmail { get; private set; }
    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }
    public OptionalText Observation { get; private set; }
    public ActiveStatus Active { get; private set; }

    private Customer(
        CustomerId customerId,
        VendorId vendorId,
        Cnpj cnpj,
        NonEmptyText corporateName,
        NonEmptyText taxId,
        NonEmptyText tradeName,
        NonEmptyText segment,
        Email? billingEmail,
        Email nfeEmail,
        Phone? landline,
        Phone? mobile,
        OptionalText observation,
        ActiveStatus active
    )
        : base(customerId)
    {
        // _orders = new List<OrderId>();
        Vendor = vendorId;
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
        VendorId vendorId,
        string cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment,
        string? billingEmail,
        string nfeEmail,
        string? landline,
        string? mobile,
        string observation
    )
    {
        var customerId = CustomerId.Generate();
        var cnpjObj = Cnpj.Create(cnpj);
        var corporateNameObj = NonEmptyText.Create(corporateName);
        var taxIdObj = NonEmptyText.Create(taxId);
        var tradeNameObj = NonEmptyText.Create(tradeName);
        var segmentObj = NonEmptyText.Create(segment);
        var billingEmailObj = billingEmail == null ? null : Email.Create(billingEmail);
        var nfeEmailObj = Email.Create(nfeEmail);
        var landlineObj = landline == null ? null : Phone.Create(landline);
        var mobileObj = mobile == null ? null : Phone.Create(mobile);
        var observationObj = OptionalText.Create(observation);
        var active = ActiveStatus.Active;

        return new Customer(
            customerId,
            vendorId,
            cnpjObj,
            corporateNameObj,
            taxIdObj,
            tradeNameObj,
            segmentObj,
            billingEmailObj,
            nfeEmailObj,
            landlineObj,
            mobileObj,
            observationObj,
            active
        );
    }
}
