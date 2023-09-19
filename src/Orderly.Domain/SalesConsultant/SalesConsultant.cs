using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.SalesConsultant.Validators;
using Orderly.Domain.SalesConsultant.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.SalesConsultant;

public sealed class SalesConsultant : Entity<SalesConsultantId>, IAggregateRoot
{
    public Cpf Cpf { get; private set; }
    public string Name { get; private set; }

    public Address Address { get; private set; }

    public Email Email { get; private set; }

    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }

    public DateTime CreatedAt { get; }

    private SalesConsultant(
        Cpf cpf,
        Address address,
        string name,
        Email email,
        Phone? landline,
        Phone? mobile
    )
        : base(SalesConsultantId.Create())
    {
        Cpf = cpf;
        Address = address;
        Name = name;
        Email = email;
        Landline = landline;
        Mobile = mobile;
        CreatedAt = DateTime.Now;
    }

    public static SalesConsultant Create(
        Cpf cpf,
        Address address,
        string name,
        Email email,
        Phone? landline,
        Phone? mobile
    )
    {
        var nameTrimmed = name.Trim();

        Validate(nameTrimmed);

        return new SalesConsultant(cpf, address, name, email, landline, mobile);
    }

    private static void Validate(string name)
    {
        var salesConsultantValidator = new SalesConsultantValidator(name);
        salesConsultantValidator.Validate();
    }
}
