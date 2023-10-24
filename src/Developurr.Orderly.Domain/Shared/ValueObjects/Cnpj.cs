using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class Cnpj : ValueObject
{
    private readonly string _value;

    private Cnpj() { }

    private Cnpj(string cnpj)
    {
        _value = cnpj.Replace(".", string.Empty)
            .Replace("-", string.Empty)
            .Replace("/", string.Empty);
    }

    public static Cnpj Create(string cnpj)
    {
        var cnpjTrimmed = cnpj.Trim();

        var cnpjValidator = new CnpjValidator(cnpjTrimmed);
        cnpjValidator.Validate();

        return new Cnpj(cnpjTrimmed);
    }

    public override string ToString()
    {
        return Convert.ToUInt64(_value).ToString(@"00\.000\.000\/0000\-00");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
