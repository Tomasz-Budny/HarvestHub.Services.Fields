using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Commands.DeleteHistoryRecord
{
    public record DeleteHistoryRecordCommand(
        Guid FieldId, 
        Guid OwnerId, 
        Guid HistoryRecordId

    ) : ICommand;
}
