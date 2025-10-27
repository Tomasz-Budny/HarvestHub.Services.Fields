using HarvestHub.Services.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Commands.UpdateHistoryRecord
{
    public record UpdateHistoryRecordCommand(
        Guid FieldId, 
        Guid OwnerId, 
        HistoryRecordDto updatedHarvestHistoryRecordDto

    ) : ICommand;

}
