using MediatR;

namespace School.Domain.Abstractions;

/**
 * IDomainEvent es una abstraccion de INotification, que es una interfaz de MediatR
 se disparara cuando creemos una entidad (Student-Course)
 */
public interface IDomainEvent : INotification
{
    
}