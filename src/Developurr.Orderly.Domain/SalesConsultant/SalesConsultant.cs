using Developurr.Orderly.Domain.Customer.ValueObjects;
using Developurr.Orderly.Domain.SalesConsultant.Validators;
using Developurr.Orderly.Domain.SalesConsultant.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.SalesConsultant;

public sealed class SalesConsultant : Entity<SalesConsultantId>, IAggregateRoot
{
    private readonly List<CustomerId> _customers;
    public Cpf Cpf { get; }
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }

    private SalesConsultant(
        SalesConsultantId salesConsultantId,
        Cpf cpf,
        Address address,
        string name,
        Email email,
        Phone? landline,
        Phone? mobile
    )
        : base(salesConsultantId)
    {
        _customers = new List<CustomerId>();
        Cpf = cpf;
        Address = address;
        Name = name;
        Email = email;
        Landline = landline;
        Mobile = mobile;
    }

    public static SalesConsultant Create(
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
        var salesConsultantId = SalesConsultantId.Generate();
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

        Validate(nameTrimmed);

        return new SalesConsultant(salesConsultantId, cpf, address, nameTrimmed, email, landline, mobile);
    }

    private static void Validate(string name)
    {
        var salesConsultantValidator = new SalesConsultantValidator(name);
        salesConsultantValidator.Validate();
    }
}
