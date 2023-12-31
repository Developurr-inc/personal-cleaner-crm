using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class Phone : ValueObject
{
    public readonly string Value;

    private Phone(){ }
    private Phone(string phone)
    {
        Value = phone;
    }

    public override string ToString()
    {
        return Value;
    }

    public static Phone Create(string phone)
    {
        var phoneTrimmed = phone.Trim();

        var phoneValidator = new PhoneValidator(phoneTrimmed);
        phoneValidator.Validate();

        return new Phone(phoneTrimmed);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
