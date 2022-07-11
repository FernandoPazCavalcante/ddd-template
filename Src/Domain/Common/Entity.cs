namespace Domain.Common;

public class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Events = new List<Event>();
    }


    public Guid Id { get; private set; }

    public DateTime CreatedAt { get; private set; }
    
    protected List<Event> Events { get; private set; }

    public DateTime? ModifiedAt { get; set; }

    protected void SetEvent(Event domainEvent)
    {
        Events.Add(domainEvent);
    }
}
