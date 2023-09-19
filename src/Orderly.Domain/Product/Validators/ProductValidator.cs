using Orderly.Domain.Validation;

namespace Orderly.Domain.Product.Validators;

public class ProductValidator : Validator
{
    private readonly string _name;
    
    public const int NameMinLength = 5;
    public const int NameMaxLength = 255;
    
    public ProductValidator(string name)
    {
        _name = name;
    }
    
    public override void Validate()
    {
       
        ValidateProductName();

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }
    
    private void ValidateProductName()
    {
        const string fieldName = "Name";

        ValidationRules.ValidateRequired(_name, fieldName, this);
        ValidationRules.ValidateStringLength(_name, fieldName, NameMinLength, NameMaxLength, this);
    }
}