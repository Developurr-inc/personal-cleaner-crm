using Developurr.Orderly.Domain.Validation;

namespace Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

public sealed class CpfValidator : Validator
{
    private readonly string _cpf;

    public CpfValidator(string cpf)
    {
        _cpf = cpf;
    }

    public override void Validate()
    {
        ValidateCpf("CPF");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateCpf(string fieldName)
    {
        ValidationRules.ValidateRequired(_cpf, fieldName, this);
        ValidationRules.ValidateCpf(_cpf, fieldName, this);
    }
}
