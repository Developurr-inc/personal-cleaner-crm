using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Manager.Validators;
using Orderly.Domain.Manager.ValueObjects;
using Orderly.Domain.SalesConsultant.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Manager;

public sealed class Manager : Entity<ManagerId>, IAggregateRoot
{
    private readonly List<SalesConsultantId> _salesConsultants;
    public Cpf Cpf { get; }
    public Address Address { get; private set; }
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }

    private Manager(
        ManagerId managerId,
        Cpf cpf,
        Address address,
        string name,
        Email email,
        Phone? landline,
        Phone? mobile
    )
        : base(managerId)
    {
        _salesConsultants = new List<SalesConsultantId>();
        Cpf = cpf;
        Address = address;
        Name = name;
        Email = email;
        Landline = landline;
        Mobile = mobile;
    }

    public static Manager Create(
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
        string nfeEmailValue,
        string? landlineValue,
        string? mobileValue
    )
    {
        var managerId = ManagerId.Generate();
        var nameTrimmed = name.Trim();
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
        var nfeEmail = Email.Create(nfeEmailValue);
        var landline = landlineValue == null ? null : Phone.Create(landlineValue);
        var mobile = mobileValue == null ? null : Phone.Create(mobileValue);

        Validate(nameTrimmed);

        return new Manager(managerId, cpf, address, nameTrimmed, nfeEmail, landline, mobile);
    }

    private static void Validate(string name)
    {
        var managerValidator = new ManagerValidator(name);
        managerValidator.Validate();
    }
}
