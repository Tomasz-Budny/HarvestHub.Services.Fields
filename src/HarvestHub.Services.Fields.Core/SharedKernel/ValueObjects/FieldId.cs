namespace HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects
{
    public record FieldId
    {
        public Guid Value { get; }

        public FieldId(Guid value)
        {
            Value = value;
        }

        public static implicit operator FieldId(Guid value) => new(value);

        public static implicit operator Guid(FieldId fieldId) => fieldId.Value;
    }
}
