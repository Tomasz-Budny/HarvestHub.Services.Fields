using HarvestHub.Services.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Dtos
{
    public record FertilizationHistoryRecordDto(
        Guid Id,
        DateTime Date,
        FertilizerType FertilizerType,
        double Amount

    ) : HistoryRecordDto(Id, Date);
}
