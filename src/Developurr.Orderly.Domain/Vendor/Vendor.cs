using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.Vendor.ValueObjects;

namespace Developurr.Orderly.Domain.Vendor;

public sealed class Vendor : Entity<VendorId>, IAggregateRoot
{
    // private readonly List<CustomerId> _customers;
    public Cpf Cpf { get; }
    public NonEmptyText Name { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }
    public ActiveStatus Active { get; private set; }

    private Vendor(
        VendorId vendorId,
        Cpf cpf,
        Address address,
        NonEmptyText name,
        Email email,
        Phone? landline,
        Phone? mobile,
        ActiveStatus active
    )
        : base(vendorId)
    {
        // _customers = new List<CustomerId>();
        Cpf = cpf;
        Address = address;
        Name = name;
        Email = email;
        Landline = landline;
        Mobile = mobile;
        Active = active;
    }

    public void Deactivate()
    {
        if (Active.IsActive)
            Active = ActiveStatus.Inactive;
    }

    public static Vendor Create(
        string cpf,
        string street,
        int number,
        string complement,
        string zipCode,
        string neighborhood,
        string city,
        string state,
        string country,
        string name,
        string email,
        string? landline,
        string? mobile
    )
    {
        var vendorId = VendorId.Generate();
        var cpfObj = Cpf.Create(cpf);
        var addressObj = Address.Create(
            street,
            number,
            complement,
            zipCode,
            neighborhood,
            city,
            state,
            country
        );
        var nameObj = NonEmptyText.Create(name);
        var emailObj = Email.Create(email);
        var landlineObj = landline == null ? null : Phone.Create(landline);
        var mobileObj = mobile == null ? null : Phone.Create(mobile);
        var active = ActiveStatus.Active;

        return new Vendor(
            vendorId,
            cpfObj,
            addressObj,
            nameObj,
            emailObj,
            landlineObj,
            mobileObj,
            active
        );
    }
}
