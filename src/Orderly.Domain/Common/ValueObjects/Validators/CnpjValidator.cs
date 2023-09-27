using Orderly.Domain.Validation;

namespace Orderly.Domain.Common.ValueObjects.Validators;

public sealed class CnpjValidator : Validator
{
    private readonly string _cnpj;

    public CnpjValidator(string cnpj)
    {
        _cnpj = cnpj;
    }

    public override void Validate()
    {
        ValidateCnpj("CNPJ");

        if (HasErrors())
            ThrowEntityValidationExceptionWithValidationErrors();
    }

    private void ValidateCnpj(string fieldName)
    {
        ValidationRules.ValidateRequired(_cnpj, fieldName, this);
        ValidationRules.ValidateCnpj(_cnpj, fieldName, this);
    }
}
