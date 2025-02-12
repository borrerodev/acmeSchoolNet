namespace School.Domain.Entities.Courses.Events;

using School.Domain.Abstractions;

public sealed record CourseCreatedDomainEvent(Guid CourseId) : IDomainEvent;
  
