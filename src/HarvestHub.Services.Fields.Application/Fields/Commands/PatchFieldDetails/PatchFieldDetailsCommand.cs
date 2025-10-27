using HarvestHub.Services.Fields.Core.Fields.Primitives;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Fields.Commands.PatchFieldDetails
{
    public record PatchFieldDetailsCommand(
        Guid FieldId, 
        Guid OwnerId, 
        string? Name,
        FieldClassStatus? Class,
        OwnershipStatus? OwnershipStatus,
        string? Color
    ) : ICommand;
}
