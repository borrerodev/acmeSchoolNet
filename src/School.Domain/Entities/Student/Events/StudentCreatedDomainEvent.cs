using School.Domain.Abstractions;

namespace School.Domain.Entities.Student.Events;

public sealed record StudentCreatedDomainEvent(Guid StudentId) : IDomainEvent
{
}
