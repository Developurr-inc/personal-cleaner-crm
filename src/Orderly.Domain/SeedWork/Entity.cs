namespace Orderly.Domain.SeedWork;

public abstract class Entity<TIdentifier>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    private readonly List<IDomainEvent> _domainEventsReadOnly;

    public TIdentifier Id { get; }
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEventsReadOnly;

    protected Entity()
    {
        Id = default(TIdentifier) ?? throw new InvalidOperationException();
        _domainEventsReadOnly = new List<IDomainEvent>(_domainEvents.AsReadOnly());
    }

    protected Entity(TIdentifier id)
    {
        if (!IsTransient())
            throw new InvalidOperationException("Cannot set ID for an existing entity.");

        Id = id;
        _domainEventsReadOnly = new List<IDomainEvent>(_domainEvents.AsReadOnly());
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public sealed override bool Equals(object? obj)
    {
        if (obj is not Entity<TIdentifier> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (IsTransient() || other.IsTransient())
            return false;

        return Id?.Equals(other.Id) ?? false;
    }

    public sealed override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }

    public static bool operator ==(Entity<TIdentifier> left, Entity<TIdentifier> right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            return true;

        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Entity<TIdentifier> left, Entity<TIdentifier> right)
    {
        return !(left == right);
    }

    private bool IsTransient()
    {
        return Equals(Id, default(TIdentifier));
    }
}
