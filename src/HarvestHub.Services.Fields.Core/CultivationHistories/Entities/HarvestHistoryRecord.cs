using HarvestHub.Services.Fields.Core.CultivationHistories.Primitives;
using HarvestHub.Services.Fields.Core.CultivationHistories.ValueObjects;

namespace HarvestHub.Services.Fields.Core.CultivationHistories.Entities
{
    public class HarvestHistoryRecord : HistoryRecord
    {
        public Amount Amount { get; private set; }
        public CropType CropType { get; private set; }
        public Humidity Humidity { get; private set; }
        public HarvestHistoryRecord(
            HistoryRecordId id,
            DateTime date,
            Amount amount,
            CropType cropType,
            Humidity humidity

        ) : base(id, date)
        {
            Amount = amount;
            CropType = cropType;
            Humidity = humidity;
        }

        public override void Update(HistoryRecord updatedHistoryRecord)
        {
            base.Update(updatedHistoryRecord);

            var updatedHarvestHistoryRecord = (HarvestHistoryRecord)updatedHistoryRecord;

            Amount = updatedHarvestHistoryRecord.Amount;
            CropType = updatedHarvestHistoryRecord.CropType;
            Humidity = updatedHarvestHistoryRecord.Humidity;
        }
    }
}
