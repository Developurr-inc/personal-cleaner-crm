using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class Cpf : ValueObject
{
    private readonly string _value;

    private Cpf() { }

    private Cpf(string cpf)
    {
        _value = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
    }

    public static Cpf Create(string cpf)
    {
        var cpfTrimmed = cpf.Trim();

        var cpfValidator = new CpfValidator(cpfTrimmed);
        cpfValidator.Validate();

        return new Cpf(cpfTrimmed);
    }

    public override string ToString()
    {
        return Convert.ToUInt64(_value).ToString(@"000\.000\.000\-00");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
