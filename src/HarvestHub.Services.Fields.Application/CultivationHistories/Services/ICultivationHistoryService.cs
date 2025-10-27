using HarvestHub.Services.Fields.Core.CultivationHistories.Aggregates;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Services
{
    public interface ICultivationHistoryService
    {
        Task<CultivationHistory> GetByFieldId(Guid fieldId, Guid ownerId, CancellationToken cancellationToken);
        Task<bool> ExistsByFieldId(Guid fieldId, CancellationToken cancellationToken);
    }
}
