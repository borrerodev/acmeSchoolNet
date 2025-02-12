using School.Domain.Abstractions;

namespace School.Domain.Entities.Students.Events;

public sealed record StudentCreatedDomainEvent(Guid StudentId) : IDomainEvent
{
}
