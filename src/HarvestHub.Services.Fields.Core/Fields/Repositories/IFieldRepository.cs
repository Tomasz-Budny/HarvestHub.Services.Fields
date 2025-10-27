using HarvestHub.Services.Fields.Core.Fields.Aggregates;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Services.Fields.Core.Fields.Repositories
{
    public interface IFieldRepository
    {
        Task AddAsync (Field field, CancellationToken cancellationToken);
        Task DeleteAsync (Field field, CancellationToken cancellationToken);
        Task UpdateAsync (Field field, CancellationToken cancellationToken);
        Task<Field?> GetAsync (FieldId fieldId, OwnerId ownerId, CancellationToken cancellationToken);
    }
}
