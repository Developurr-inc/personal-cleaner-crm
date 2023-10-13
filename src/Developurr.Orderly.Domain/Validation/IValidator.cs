namespace Developurr.Orderly.Domain.Validation;

public interface IValidator
{
    public void AddValidationError(string message);
}
