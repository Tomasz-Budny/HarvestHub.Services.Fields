using HarvestHub.Shared.Events;

namespace HarvestHub.Shared.Messaging
{
    internal interface IAsyncEventDispatcher
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : class, IEvent;
    }
}
