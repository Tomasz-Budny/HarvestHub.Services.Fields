using HarvestHub.Shared.Events;

namespace HarvestHub.Services.Fields.Shared.Events.Fields
{
    public record FieldCreated(
        Guid FieldId, 
        Guid OwnerId, 
        string Name, 
        double Area

    ) : IEvent;
}
