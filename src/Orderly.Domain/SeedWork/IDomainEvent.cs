namespace Orderly.Domain.SeedWork;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
    Guid EventId { get; }
    string EventName { get; }
}
