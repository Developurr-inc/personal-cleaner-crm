using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects.Validators;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class ZipCode : ValueObject
{
    private readonly string _value;

    private ZipCode(string zipCode)
    {
        _value = zipCode;
    }

    public static ZipCode Create(string zipCode)
    {
        var zipCodeTrimmed = zipCode.Trim();

        var zipCodeValidator = new ZipCodeValidator(zipCodeTrimmed);
        zipCodeValidator.Validate();

        return new ZipCode(zipCodeTrimmed);
    }

    public override string ToString()
    {
        return _value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}