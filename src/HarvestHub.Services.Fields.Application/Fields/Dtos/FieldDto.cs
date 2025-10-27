using HarvestHub.Services.Fields.Application.Dtos;

namespace HarvestHub.Services.Fields.Application.Fields.Dtos
{
    public record FieldDto(
        Guid Id,
        string Name, 
        PointDto Center, 
        double Area, 
        string Color, 
        AddressDto Address,
        IEnumerable<VertexDto> Paths
    );
}
