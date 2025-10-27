using HarvestHub.Services.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Dtos
{
    public record UpdateFertilizationHistoryRecordRequest(
        DateTime Date,
        FertilizerType FertilizerType,
        double Amount
    );
}
