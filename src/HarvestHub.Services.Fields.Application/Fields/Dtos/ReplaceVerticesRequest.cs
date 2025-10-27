using HarvestHub.Services.Fields.Application.Dtos;

namespace HarvestHub.Services.Fields.Application.Fields.Dtos
{
    public record ReplaceVerticesRequest(
        IEnumerable<ReplaceVertexDto> Vertices, 
        double Area, 
        PointDto Center
    );
}
