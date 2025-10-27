namespace HarvestHub.Services.Fields.Core.Fields.ValueObjects
{
    public record Order
    {
        public uint Value { get; }

        public Order(uint value)
        {
            Value = value;
        }


        public static implicit operator Order(uint value) => new(value);

        public static implicit operator uint(Order order) => order.Value;
    }
}
