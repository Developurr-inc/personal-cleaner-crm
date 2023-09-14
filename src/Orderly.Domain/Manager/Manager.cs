using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Manager.Validators;
using Orderly.Domain.Manager.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Manager;

public class Manager : AggregateRoot<ManagerId>
{
    public Cpf Cpf { get; private set; }
    public Address Address { get; private set; }
    public string ManagerName { get; private set; }
    public Email NfeEmail { get; private set; }
    
    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }
    
    private Manager(
        Cpf cpf,
        Address address,
        string managerName,
        Email nfeEmail,
        Phone? landline,
        Phone? mobile
    ) : base(ManagerId.Create())
    {
        Cpf = cpf;
        Address = address;
        ManagerName = managerName;
        NfeEmail = nfeEmail;
        Landline = landline;
        Mobile = mobile;
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