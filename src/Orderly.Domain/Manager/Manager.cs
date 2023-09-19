using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Manager.Validators;
using Orderly.Domain.Manager.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Manager;

public sealed class Manager : Entity<ManagerId>, IAggregateRoot
{
    public Cpf Cpf { get; private set; }
    public Address Address { get; private set; }
    public string Name { get; private set; }
    public Email Email { get; private set; }

    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }

    public DateTime CreatedAt { get; }

    private Manager(
        Cpf cpf,
        Address address,
        string name,
        Email email,
        Phone? landline,
        Phone? mobile
    )
        : base(ManagerId.Create())
    {
        Cpf = cpf;
        Address = address;
        Name = name;
        Email = email;
        Landline = landline;
        Mobile = mobile;
        CreatedAt = DateTime.Now;
    }

    public static Manager Create(
        Cpf cpf,
        Address address,
        string name,
        Email nfeEmail,
        Phone? landline,
        Phone? mobile
    )
    {
        var nameTrimmed = name.Trim();

        Validate(nameTrimmed);

        return new Manager(cpf, address, nameTrimmed, nfeEmail, landline, mobile);
    }

    private static void Validate(string name)
    {
        var managerValidator = new ManagerValidator(name);
        managerValidator.Validate();
    }
}
