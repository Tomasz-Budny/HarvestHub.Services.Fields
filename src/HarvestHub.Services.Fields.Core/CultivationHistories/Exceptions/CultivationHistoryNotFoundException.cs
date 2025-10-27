using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Services.Fields.Core.CultivationHistories.Exceptions
{
    public class CultivationHistoryNotFoundException : HarvestHubException
    {
        public Guid CultivationHistoryId { get; }
        public CultivationHistoryNotFoundException(Guid cultivationHistoryId) : base($"Cultivation history with provided id {cultivationHistoryId} was not found!")
        {
            CultivationHistoryId = cultivationHistoryId;
        }
    }
}
