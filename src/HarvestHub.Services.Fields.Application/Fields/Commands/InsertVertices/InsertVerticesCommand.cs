using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Fields.Commands.InsertVertices
{
    public record InsertVerticesCommand(
        Guid FieldId, 
        Guid OwnerId, 
        IEnumerable<VertexDto> Vertices, 
        double Area

    ) : ICommand;
}
