using HarvestHub.Shared.Events;

namespace HarvestHub.Services.Fields.Shared.Events.Fields
{
    public record FieldDeleted(Guid FieldId, Guid OwnerId, string Name, double Area) : IEvent;
}
