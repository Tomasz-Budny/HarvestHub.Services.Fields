using HarvestHub.Services.Fields.Application.Dtos;
using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Fields.Commands.ReplaceVertices
{
    public record ReplaceVerticesCommand(
        Guid FieldId, 
        Guid OwnerId, 
        IEnumerable<ReplaceVertexDto> Vertices, 
        double Area, 
        PointDto Center

    ) : ICommand;
}
