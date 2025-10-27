using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Services.Fields.Core.CultivationHistories.Exceptions
{
    public class CultivationHistoryWithFieldIdNotFoundException : HarvestHubException
    {
        public Guid FieldId { get; }
        public CultivationHistoryWithFieldIdNotFoundException(Guid fieldId) : base($"Cultivation history with provided field id {fieldId} was not found!")
        {
            FieldId = fieldId;
        }
    }
}
