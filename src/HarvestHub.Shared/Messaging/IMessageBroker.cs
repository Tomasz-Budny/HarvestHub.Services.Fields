using HarvestHub.Shared.Events;

namespace HarvestHub.Shared.Messaging
{
    public interface IMessageBroker
    {
        Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default);
    }
}
