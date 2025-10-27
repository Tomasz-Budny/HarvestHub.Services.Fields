using HarvestHub.Shared.Events;

namespace HarvestHub.Services.Fields.Shared.Events.Fields
{
    public record FieldAreaChanged(Guid FieldId, Guid OwnerId, double OldArea, double NewArea) : IEvent;
}
