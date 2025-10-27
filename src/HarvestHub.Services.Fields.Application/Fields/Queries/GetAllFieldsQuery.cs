using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Fields.Queries
{
    public record GetAllFieldsQuery(Guid OwnerId) : IQuery<IEnumerable<FieldDto>>;
}
