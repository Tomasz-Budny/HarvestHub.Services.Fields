using HarvestHub.Services.Fields.Core.CultivationHistories.Primitives;
using HarvestHub.Services.Fields.Core.CultivationHistories.ValueObjects;

namespace HarvestHub.Services.Fields.Core.CultivationHistories.Entities
{
    public class FertilizationHistoryRecord : HistoryRecord
    {
        public FertilizerType FertilizerType { get; private set; }
        public Amount Amount { get; private set; }
        public FertilizationHistoryRecord(
            HistoryRecordId id,
            DateTime date,
            FertilizerType fertilizerType,
            Amount amount

        ) : base(id, date)
        {
            FertilizerType = fertilizerType;
            Amount = amount;
        }

        public override void Update(HistoryRecord updatedHistoryRecord)
        {
            base.Update(updatedHistoryRecord);

            var updatedFertilizationHistoryRecord = (FertilizationHistoryRecord)updatedHistoryRecord;

            Amount = updatedFertilizationHistoryRecord.Amount;
            FertilizerType = updatedFertilizationHistoryRecord.FertilizerType;
        }
    }
}
