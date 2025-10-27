using HarvestHub.Shared.Events;
using System.Threading.Channels;

namespace HarvestHub.Shared.Messaging
{
    internal interface IEventChannel
    {
        ChannelReader<IEvent> Reader { get; }
        ChannelWriter<IEvent> Writer { get; }
    }
}
