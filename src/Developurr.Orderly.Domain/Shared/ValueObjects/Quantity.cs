using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.SeedWork;

namespace Developurr.Orderly.Domain.Shared.ValueObjects;

public sealed class Quantity : ValueObject
{
    public readonly int Value;

    private Quantity(int value)
    {
        Value = value;
    }

    public static Quantity Create(int quantity)
    {
        if (int.IsNegative(quantity))
        {
            throw new ValidationException(nameof(quantity));
        }

        return new Quantity(quantity);
    }

    public static Quantity operator +(Quantity left, Quantity right)
    {
        return Create(left.Value + right.Value);
    }

    public static Quantity operator -(Quantity left, Quantity right)
    {
        return Create(left.Value - right.Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}