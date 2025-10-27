using HarvestHub.Services.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Dtos
{
    public record AddFertilizationHistoryRecordByFieldIdRequest(
        DateTime Date,
        double Amount,
        FertilizerType FertilizerType
    );
}
