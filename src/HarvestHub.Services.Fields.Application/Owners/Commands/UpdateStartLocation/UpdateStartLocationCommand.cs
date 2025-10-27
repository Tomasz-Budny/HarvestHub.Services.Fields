using HarvestHub.Services.Fields.Application.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Owners.Commands.UpdateStartLocation
{
    public record UpdateStartLocationCommand (
        Guid OwnerId,
        PointDto Point
    ) : ICommand;
}
