using HarvestHub.Services.Fields.Application.Dtos;

namespace HarvestHub.Services.Fields.Application.Fields.Dtos
{
    public record CreateFieldRequest(
        string Name, 
        PointDto Center, 
        double Area, 
        string Color, 
        IEnumerable<CreateVertexDto> Vertices
    );
}
