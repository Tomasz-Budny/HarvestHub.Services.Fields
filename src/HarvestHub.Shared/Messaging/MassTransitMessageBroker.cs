using HarvestHub.Shared.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace HarvestHub.Shared.Messaging
{
    class MassTransitMessageBroker : IMessageBroker
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<MassTransitMessageBroker>? _logger;

        public MassTransitMessageBroker(IPublishEndpoint publishEndpoint, ILogger<MassTransitMessageBroker>? logger = null)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default)
        {
            if (@event is null) throw new ArgumentNullException(nameof(@event));

            var messageType = @event.GetType();

            await _publishEndpoint.Publish(@event, messageType, context =>
            {
                return Task.CompletedTask;
            }, cancellationToken);

            _logger?.LogDebug("Published event {EventType}", messageType.Name);
        }
    }
}
