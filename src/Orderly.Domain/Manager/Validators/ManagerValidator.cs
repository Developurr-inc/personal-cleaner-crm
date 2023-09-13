namespace Orderly.Domain.Manager.Validators;

public class ManagerValidator : Validator
{
    private readonly string _managerName;
    
    public const int ManagerNameMinLength = 1;
    public const int ManagerNameMaxLength = 255;
    
    
    public ManagerValidator(
        string managerName
    )
    {
        _managerName = managerName;
    }
    
    
    public override void Validate()
    {
        ValidateManagerName();
        
        if (HasErrors())
        {
            ThrowEntityValidationExceptionWithValidationErrors();
        }
    }
    
    
    private void ValidateManagerName()
    {
        const string fieldName = "Manager Name";

        ValidationRules.ValidateRequired(_managerName, fieldName, this);
        ValidationRules.ValidateStringLength(
            _managerName,
            fieldName,
            ManagerNameMinLength,
            ManagerNameMaxLength,
            this
        );
    }
}