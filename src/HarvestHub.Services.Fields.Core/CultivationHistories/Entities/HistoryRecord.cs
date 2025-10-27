using HarvestHub.Services.Fields.Core.CultivationHistories.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Services.Fields.Core.CultivationHistories.Entities
{
    public abstract class HistoryRecord : Entity<HistoryRecordId>
    {
        public DateTime Date { get; set; }

        protected HistoryRecord(HistoryRecordId id, DateTime date) : base(id)
        {
            Date = date;
        }

        public virtual void Update(HistoryRecord updatedHistoryRecord)
        {
            Date = updatedHistoryRecord.Date;
        }
    }
}
