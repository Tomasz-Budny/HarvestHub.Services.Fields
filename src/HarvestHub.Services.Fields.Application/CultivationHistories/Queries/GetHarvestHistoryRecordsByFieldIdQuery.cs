using HarvestHub.Services.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Queries
{
    public record GetHarvestHistoryRecordsByFieldIdQuery(Guid FieldId, Guid OwnerId) : IQuery<IEnumerable<HarvestHistoryRecordDto>>;
}
