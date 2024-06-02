using CleanArc_Kevin.Core.Domain.Events;

namespace CleanArc_Kevin.Core.Contracts.ApplicationServices.Events;

public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent;
}