using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Services.Fields.Core.CultivationHistories.Exceptions
{
    public class HistoryRecordAlreadyExistsException : HarvestHubException
    {
        public Guid HistoryRecordId { get; set; }
        public HistoryRecordAlreadyExistsException(Guid historyRecordId) : base($"history record with provided id {historyRecordId} already exists!")
        {
            HistoryRecordId = historyRecordId;
        }
    }
}
