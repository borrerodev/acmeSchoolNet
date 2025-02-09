namespace School.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }

    public Entity()
    {
        
    }
     // Constructor to initialize Id
    protected Entity(Guid id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
    }

    // Add domain event to the list
    public IReadOnlyList<IDomainEvent> GetDomainEvents => _domainEvents.ToList(); 

    // Clear domain events
    public void ClearDomainEvents() => _domainEvents.Clear();

    // Add domain event to the list
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}    
