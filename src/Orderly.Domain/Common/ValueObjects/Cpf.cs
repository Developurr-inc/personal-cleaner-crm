using Orderly.Domain.SeedWork;
using Orderly.Domain.Common.ValueObjects.Validators;

namespace Orderly.Domain.Common.ValueObjects;

public sealed class Cpf : ValueObject
{
    private readonly string _value;

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

    public string Format()
    {
        return Convert.ToUInt64(_value).ToString(@"000\.000\.000\-00");
    }

    public override string ToString()
    {
        return Format();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
