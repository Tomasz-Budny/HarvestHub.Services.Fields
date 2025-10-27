using HarvestHub.Services.Fields.Core.Fields.Exceptions;

namespace HarvestHub.Services.Fields.Core.Fields.ValueObjects
{
    public record Longitude
    {
        public double Value { get; }

        public Longitude(double value)
        {
            if(value < -180 || value > 180)
            {
                throw new InvalidLongitudeValueException(value);
            }

            Value = value;
        }

        public static implicit operator Longitude(double value) => new(value);

        public static implicit operator double(Longitude longitude) => longitude.Value;
    }
}
