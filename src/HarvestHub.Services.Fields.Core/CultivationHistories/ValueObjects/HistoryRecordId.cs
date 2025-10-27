namespace HarvestHub.Services.Fields.Core.CultivationHistories.ValueObjects
{
    public record HistoryRecordId
    {
        public Guid Value { get; }

        public HistoryRecordId(Guid value)
        {
            Value = value;
        }

        public static implicit operator HistoryRecordId(Guid value) => new(value);

        public static implicit operator Guid(HistoryRecordId historyRecordId) => historyRecordId.Value;
    }
}
