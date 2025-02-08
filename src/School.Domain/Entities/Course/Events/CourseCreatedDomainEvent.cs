namespace School.Domain.Entities.Course.Events;

using School.Domain.Abstractions;

public sealed record CourseCreatedDomainEvent(Guid CourseId) : IDomainEvent;
  
