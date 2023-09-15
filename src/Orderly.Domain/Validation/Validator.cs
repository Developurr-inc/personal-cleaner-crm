using Orderly.Domain.Exceptions;

namespace Orderly.Domain.Validation;

public abstract class Validator : IValidator
{
    private readonly List<string> _validationErrors = new();


    public abstract void Validate();


    public void AddValidationError(string message)
    {
        _validationErrors.Add(message);
    }


    protected bool HasErrors()
    {
        return _validationErrors.Count > 0;
    }


    protected void ThrowEntityValidationExceptionWithValidationErrors()
    {
        if (HasErrors())
            throw new EntityValidationException(
                "There are validation errors.",
                GetValidationErrors()
            );
    }


    private IEnumerable<string> GetValidationErrors()
    {
        return new List<string>(_validationErrors).AsReadOnly();
    }
}