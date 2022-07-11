namespace Domain.Common;

public abstract class Event : Entity
{
    public Guid AggregateId { get; private set; }

    protected Event(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}
