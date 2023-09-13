using Orderly.Domain.Common.ValueObjects;

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
        Phone landline,
        Phone mobile
    )
    {
        Cpf = cpf;
        Address = address;
        ManagerName = managerName;
        NfeEmail = nfeEmail;
        Landline = landline;
        Mobile = mobile;
    }
    
    
    public void UpdateManagerName(string managerName)
    {
        var managerNameTrimmed = managerName.Trim();

        Validate(
            managerNameTrimmed
        );

        ManagerName = managerNameTrimmed;
    }
    
    
    public void ChangeCpf(Cpf cpf)
    {
        Cpf = cpf;
    }
    
    
    public void ChangeAddress(Address address)
    {
        Address = address;
    }
    
    
    public void ChangeNfeEmail(Email nfeEmail)
    {
        Email = nfeEmail;
    }
    
    
    public void ChangeLandline(Phone landline)
    {
        Phone = landline;
    }
    
    
    public void ChangeMobile(Phone mobile)
    {
        Phone = mobile;
    }
    
    
    public static Manager Create(
        Cpf cpf,
        Address address,
        string managerName,
        Email nfeEmail,
        Phone landline,
        Phone mobile
    )
    {
        var mananerNameTrimmed = managerName.Trim();

        Validate(
            managerNameTrimmed
        );

        return new Manager(
            Cpf cpf,
            Address address,
            string managerName,
            Email nfeEmail,
            Phone landline,
            Phone mobile
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