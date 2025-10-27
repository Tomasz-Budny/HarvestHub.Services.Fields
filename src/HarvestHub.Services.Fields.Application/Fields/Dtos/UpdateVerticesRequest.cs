using HarvestHub.Services.Fields.Application.Dtos;

namespace HarvestHub.Services.Fields.Application.Fields.Dtos
{
    public record UpdateVerticesRequest(
        IEnumerable<UpdateVertexDto> Vertices, 
        double Area, 
        PointDto Center
    );
}
