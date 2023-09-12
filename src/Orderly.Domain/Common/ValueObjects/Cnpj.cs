using Orderly.Domain.SeedWork;
using Orderly.Domain.Common.ValueObjects.Validators;

namespace Orderly.Domain.Common.ValueObjects;

public sealed class Cnpj : ValueObject
{
    public string Value { get; }


    private Cnpj(string cnpj)
    {
        Value = cnpj;
    }


    public static Cnpj Create(string cnpj)
    {
        var cnpjTrimmed = cnpj.Trim();

        var cnpjValidator = new CnpjValidator(cnpjTrimmed);
        cnpjValidator.Validate();

        return new Cnpj(cnpjTrimmed);
    }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}