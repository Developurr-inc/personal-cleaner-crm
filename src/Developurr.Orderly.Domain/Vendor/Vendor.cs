using Developurr.Orderly.Domain.Customer.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.Vendor.Validators;
using Developurr.Orderly.Domain.Vendor.ValueObjects;

namespace Developurr.Orderly.Domain.Vendor;

public sealed class Vendor : Entity<VendorId>, IAggregateRoot
{
    private readonly List<CustomerId> _customers;
    public Cpf Cpf { get; }
    public NonEmptyText Name { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }

    private Vendor(
        VendorId vendorId,
        Cpf cpf,
        Address address,
        NonEmptyText name,
        Email email,
        Phone? landline,
        Phone? mobile
    )
        : base(vendorId)
    {
        _customers = new List<CustomerId>();
        Cpf = cpf;
        Address = address;
        Name = name;
        Email = email;
        Landline = landline;
        Mobile = mobile;
    }

    public static Vendor Create(
        string cpfValue,
        string street,
        int number,
        string complement,
        string zipCode,
        string neighborhood,
        string city,
        string state,
        string country,
        string name,
        string emailValue,
        string? landlineValue,
        string? mobileValue
    )
    {
        var vendorId = VendorId.Generate();
        var cpf = Cpf.Create(cpfValue);
        var address = Address.Create(
            street,
            number,
            complement,
            zipCode,
            neighborhood,
            city,
            state,
            country
        );
        var nameTrimmed = name.Trim();
        var email = Email.Create(emailValue);
        var landline = landlineValue == null ? null : Phone.Create(landlineValue);
        var mobile = mobileValue == null ? null : Phone.Create(mobileValue);

        return new Vendor(vendorId, cpf, address, nameTrimmed, email, landline, mobile);
    }
    
}
