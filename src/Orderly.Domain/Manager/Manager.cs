using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Manager.Validators;
using Orderly.Domain.Manager.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Manager;

public class Manager : Entity<ManagerId>, IAggregateRoot
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
    ) : base(ManagerId.Create())
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
        string managerName,
        Email nfeEmail,
        Phone? landline,
        Phone? mobile
    )
    {
        var managerNameTrimmed = managerName.Trim();

        Validate(
            managerNameTrimmed
        );

        return new Manager(
            cpf,
            address,
            managerName,
            nfeEmail,
            landline,
            mobile
        );
    }
    
    
    private static void Validate(
        string managerName
    )
    {
        var managerValidator = new ManagerValidator(
            managerName
        );
        managerValidator.Validate();
    }
}