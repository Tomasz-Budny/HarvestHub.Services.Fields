using HarvestHub.Services.Fields.Application.Owners.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Owners.Queries
{
    public record GetOwnerStartLocationQuery(Guid OwnerId) : IQuery<StartLocationDto>;
}
