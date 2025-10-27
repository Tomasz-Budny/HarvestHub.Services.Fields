namespace HarvestHub.Services.Fields.Core.CultivationHistories.ValueObjects
{
    public record CultivationHistoryId
    {
        public Guid Value { get; }

        public CultivationHistoryId(Guid value)
        {
            Value = value;
        }

        public static implicit operator CultivationHistoryId(Guid value) => new(value);

        public static implicit operator Guid(CultivationHistoryId cultivationHistoryId) => cultivationHistoryId.Value;
    }
}
