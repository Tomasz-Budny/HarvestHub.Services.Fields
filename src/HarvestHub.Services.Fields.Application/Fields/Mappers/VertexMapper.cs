using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Services.Fields.Core.Fields.Entities;

namespace HarvestHub.Services.Fields.Application.Fields.Mappers
{
    public static class VertexMapper
    {
        public static Vertex Map(CreateVertexDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var id = Guid.NewGuid();
            return new Vertex(id, 0, dto.Lat, dto.Lng);
        }

        public static Vertex Map(ReplaceVertexDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var id = Guid.NewGuid();
            return new Vertex(id, 0, dto.Lat, dto.Lng);
        }

        public static Vertex Map(UpdateVertexDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Vertex(dto.VertexId, 0, dto.Lat, dto.Lng);
        }

        public static Vertex Map(VertexDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var id = Guid.NewGuid();
            return new Vertex(id, dto.Order, dto.Lat, dto.Lng);
        }

        public static VertexDto MapToDto(Vertex vertex)
        {
            return new VertexDto(vertex.Latitude, vertex.Longitude, vertex.Order);
        }
    }
}
