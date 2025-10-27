namespace HarvestHub.Services.Fields.Application.Fields.Dtos
{
    public record InsertVerticesRequest(
        IEnumerable<VertexDto> Vertices, 
        double Area
    );
}
