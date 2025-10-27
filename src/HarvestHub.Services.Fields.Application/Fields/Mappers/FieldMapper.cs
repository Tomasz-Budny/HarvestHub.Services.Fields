using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Services.Fields.Application.Mappers;
using HarvestHub.Services.Fields.Core.Fields.Aggregates;

namespace HarvestHub.Services.Fields.Application.Fields.Mappers
{
    public static class FieldMapper
    {
        public static FieldDto MapToDto(Field field)
        {
            var center = PointMapper.MapToDto(field.Center);
            var verticesDto = field.Vertices.Select(vertex => VertexMapper.MapToDto(vertex));
            var addressDto = AddressMapper.MapToDto(field.Address);

            return new FieldDto(field.Id, field.Name, center, field.Area, field.Color, addressDto, verticesDto);
        }
    }
}
