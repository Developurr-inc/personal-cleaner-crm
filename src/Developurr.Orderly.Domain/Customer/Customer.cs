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
    public NonEmptyText RazaoSocial { get; private set; }
    public NonEmptyText InscricaoSocial { get; private set; }
    public NonEmptyText NomeFantasia { get; private set; }
    public NonEmptyText Segmento { get; private set; }
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
        NonEmptyText razaoSocial,
        NonEmptyText inscricaoSocial,
        NonEmptyText nomeFantasia,
        NonEmptyText segmento,
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
        RazaoSocial = razaoSocial;
        InscricaoSocial = inscricaoSocial;
        NomeFantasia = nomeFantasia;
        Segmento = segmento;
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
        string razaoSocial,
        string inscricaoSocial,
        string nomeFantasia,
        string segmento,
        string? billingEmail,
        string nfeEmail,
        string? landline,
        string? mobile,
        string observation
    )
    {
        var customerId = CustomerId.Generate();
        var cnpjObj = Cnpj.Create(cnpj);
        var razaoSocialObj = NonEmptyText.Create(razaoSocial);
        var inscricaoSocialObj = NonEmptyText.Create(inscricaoSocial);
        var nomeFantasiaObj = NonEmptyText.Create(nomeFantasia);
        var segmentoObj = NonEmptyText.Create(segmento);
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
            razaoSocialObj,
            inscricaoSocialObj,
            nomeFantasiaObj,
            segmentoObj,
            billingEmailObj,
            nfeEmailObj,
            landlineObj,
            mobileObj,
            observationObj,
            active
        );
    }
}
