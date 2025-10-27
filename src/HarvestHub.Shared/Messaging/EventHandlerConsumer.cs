using HarvestHub.Shared.Events;
using MassTransit;

namespace HarvestHub.Shared.Messaging
{
    public class EventHandlerConsumer<TEvent> : IConsumer<TEvent> where TEvent : class, IEvent
    {
        private readonly IEventHandler<TEvent> _handler;

        public EventHandlerConsumer(IEventHandler<TEvent> handler) => _handler = handler;

        public Task Consume(ConsumeContext<TEvent> context)
            => _handler.HandleAsync(context.Message, context.CancellationToken);
    }
}
