using Orderly.Domain.SeedWork;
using Orderly.Domain.Common.ValueObjects.Validators;

namespace Orderly.Domain.Common.ValueObjects;

public sealed class Cpf : ValueObject
{
    public string Value { get; }


    private Cpf(string cpf)
    {
        Value = cpf;
    }


    public static Cpf Create(string cpf)
    {
        var cpfTrimmed = cpf.Trim();

        var cpfValidator = new CpfValidator(cpfTrimmed);
        cpfValidator.Validate();

        return new Cpf(cpfTrimmed);
    }
    
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}