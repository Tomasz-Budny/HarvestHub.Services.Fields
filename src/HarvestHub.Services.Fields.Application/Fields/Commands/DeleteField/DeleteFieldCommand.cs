using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Fields.Commands.DeleteField
{
    public record DeleteFieldCommand(
        Guid Id, 
        Guid OwnerId

    ) : ICommand;
}
