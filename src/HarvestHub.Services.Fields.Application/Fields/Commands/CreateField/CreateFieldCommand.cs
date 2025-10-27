using HarvestHub.Services.Fields.Application.Dtos;
using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Fields.Commands.CreateField
{
    public record CreateFieldCommand(
        Guid FieldId, 
        Guid OwnerId, 
        string Name, 
        PointDto Center, 
        double Area, 
        string Color, 
        IEnumerable<CreateVertexDto> Vertices

    ) : ICommand;
}
