using CleanArc_Kevin.Core.Domain.Events;

namespace CleanArc_Kevin.Core.Contracts.ApplicationServices.Events;

public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent @event);
}