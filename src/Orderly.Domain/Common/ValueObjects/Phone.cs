using Orderly.Domain.Common.ValueObjects.Validators;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Common.ValueObjects;

public sealed class Phone : ValueObject
{
    public readonly string Value;

    private Phone(string phone)
    {
        Value = phone;
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
