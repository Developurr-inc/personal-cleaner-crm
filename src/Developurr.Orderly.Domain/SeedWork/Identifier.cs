namespace Developurr.Orderly.Domain.SeedWork;

public abstract class Identifier<T> : ValueObject
{
    protected readonly T Value;

    protected Identifier(T value)
    {
        Value = value;
    }

    public sealed override string ToString()
    {
        return Value?.ToString() ?? string.Empty;
    }

    protected sealed override IEnumerable<object> GetEqualityComponents()
    {
        yield return ToString();
    }
}
