using HarvestHub.Services.Fields.Core.Fields.Exceptions;

namespace HarvestHub.Services.Fields.Core.Fields.ValueObjects
{
    public record Area
    {
        public double Value { get; }

        public Area(double value)
        {
            if(value < 0)
            {
                throw new InvalidAreaValueException(value);
            }

            Value = value;
        }

        public static implicit operator Area(double value) => new(value);

        public static implicit operator double(Area area) => area.Value;
    }
}
