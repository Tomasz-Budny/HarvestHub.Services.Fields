using HarvestHub.Services.Fields.Core.Fields.ValueObjects;

namespace HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects
{
    public record Point
    {
        public Latitude Latitude { get; set; }
        public Longitude Longitude { get; set; }

        public Point(Latitude latitude, Longitude longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Point Create(string value)
        {
            var splitPointCoordinates = value.Split('|');
            return new Point(double.Parse(splitPointCoordinates[0]), double.Parse(splitPointCoordinates.Last()));
        }

        public override string ToString() => $"{Latitude.Value}|{Longitude.Value}";
    }
}
