namespace Orderly.Domain.SeedWork;

public abstract class Identifier<T> : ValueObject
{
    protected readonly T Value;

    protected Identifier(T value)
    {
        Value = value;
    }

    public string Format()
    {
        return Value.ToString();
    }

    public sealed override string ToString()
    {
        return Format();
    }

    protected sealed override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
