namespace Orderly.Domain.SeedWork;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();


    public sealed override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (ReferenceEquals(null, obj) || obj.GetType() != GetType())
            return false;

        return Equals(obj as ValueObject);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(GetEqualityComponents().ToArray());
    }


    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right);
    }


    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(left, right);
    }


    public bool Equals(ValueObject? other)
    {
        if (ReferenceEquals(null, other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }
}