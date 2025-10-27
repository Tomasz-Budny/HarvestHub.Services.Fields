using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Services.Fields.Application.Mappers;
using HarvestHub.Services.Fields.Core.Fields.Aggregates;

namespace HarvestHub.Services.Fields.Application.Fields.Mappers
{
    public static class FieldDetailsMapper
    {
        public static FieldDetailsDto MapToDto(Field field)
        {
            var pointDto = PointMapper.MapToDto(field.Center);
            var addressDto = AddressMapper.MapToDto(field.Address);

            return new FieldDetailsDto(
                field.Name, pointDto, field.CreatedAt, field.Area, field.Class,
                field.OwnershipStatus, addressDto, field.Color);
        }
    }
}
