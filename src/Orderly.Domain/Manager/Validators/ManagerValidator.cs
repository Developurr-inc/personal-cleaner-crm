using Orderly.Domain.Validation;

namespace Orderly.Domain.Manager.Validators;

public class ManagerValidator : Validator
{
    private readonly string _name;
    
    public const int NameMinLength = 5;
    public const int NameMaxLength = 255;
    
    
    public ManagerValidator(
        string name
    )
    {
        _name = name;
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
        const string fieldName = "Name";

        ValidationRules.ValidateRequired(_name, fieldName, this);
        ValidationRules.ValidateStringLength(
            _name,
            fieldName,
            NameMinLength,
            NameMaxLength,
            this
        );
    }
}