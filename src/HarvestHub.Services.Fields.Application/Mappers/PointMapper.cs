using HarvestHub.Services.Fields.Application.Dtos;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Services.Fields.Application.Mappers
{
    public static class PointMapper
    {
        public static PointDto MapToDto(Point point)
        {
            return new PointDto(point.Latitude, point.Longitude);
        }

        public static Point Map(PointDto point)
        {
            return new Point(point.Lat, point.Lng) ;
        }
    }
}
