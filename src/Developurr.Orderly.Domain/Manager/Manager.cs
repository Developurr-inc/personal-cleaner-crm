using Developurr.Orderly.Domain.Manager.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.Manager;

public sealed class Manager : Entity<ManagerId>, IAggregateRoot
{
    // private readonly List<VendorId> _vendors;
    public Cpf Cpf { get; }
    public Address Address { get; private set; }
    public NonEmptyText Name { get; private set; }
    public Email Email { get; private set; }
    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }

    private Manager(
        ManagerId managerId,
        Cpf cpf,
        Address address,
        NonEmptyText name,
        Email email,
        Phone? landline,
        Phone? mobile
    )
        : base(managerId)
    {
        // _vendors = new List<VendorId>();
        Cpf = cpf;
        Address = address;
        Name = name;
        Email = email;
        Landline = landline;
        Mobile = mobile;
    }

    public static Manager Create(
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
        var managerId = ManagerId.Generate();
        var nameObj = NonEmptyText.Create(name);
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
        var emailObj = Email.Create(email);
        var landlineObj = landline == null ? null : Phone.Create(landline);
        var mobileObj = mobile == null ? null : Phone.Create(mobile);

        return new Manager(
            managerId,
            cpfObj,
            addressObj,
            nameObj,
            emailObj,
            landlineObj,
            mobileObj
        );
    }
}
