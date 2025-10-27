using HarvestHub.Services.Fields.Core.CultivationHistories.Primitives;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Dtos
{
    public record HarvestHistoryRecordDto(
        Guid Id,
        DateTime Date,
        CropType CropType,
        double Amount,
        uint Humidity

    ) :HistoryRecordDto(Id, Date);
}
