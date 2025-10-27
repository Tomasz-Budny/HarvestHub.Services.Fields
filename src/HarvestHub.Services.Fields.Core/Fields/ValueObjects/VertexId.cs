namespace HarvestHub.Services.Fields.Core.Fields.ValueObjects
{
    public record VertexId
    {
        public Guid Value { get; }

        public VertexId(Guid value)
        {
            Value = value;
        }

        public static implicit operator VertexId(Guid value) => new(value);

        public static implicit operator Guid(VertexId vertexId) => vertexId.Value;
    }
}
