using HarvestHub.Services.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Dtos
{
    public record AddHarvestHistoryRecordByFieldIdRequest(
        DateTime Date,
        double Amount,
        CropType CropType,
        uint Humidity
    );
}
