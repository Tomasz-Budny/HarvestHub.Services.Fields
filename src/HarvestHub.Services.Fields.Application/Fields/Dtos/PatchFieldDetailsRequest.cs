using HarvestHub.Services.Fields.Core.Fields.Primitives;

namespace HarvestHub.Services.Fields.Application.Fields.Dtos
{
    public record PatchFieldDetailsRequest(
        string? Name = null,
        FieldClassStatus? Class = null,
        OwnershipStatus? OwnershipStatus = null,
        string? Color = null
    );
}
