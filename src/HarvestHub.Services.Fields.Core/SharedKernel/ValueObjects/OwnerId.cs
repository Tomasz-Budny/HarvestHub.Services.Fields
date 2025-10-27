namespace HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects
{
    public record OwnerId
    {
        public Guid Value { get; }

        public OwnerId(Guid value)
        {
            Value = value;
        }

        public static implicit operator OwnerId(Guid value) => new(value);

        public static implicit operator Guid(OwnerId ownerId) => ownerId.Value;
    }
}
