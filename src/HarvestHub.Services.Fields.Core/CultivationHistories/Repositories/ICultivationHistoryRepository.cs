using HarvestHub.Services.Fields.Core.CultivationHistories.Aggregates;
using HarvestHub.Services.Fields.Core.CultivationHistories.ValueObjects;

namespace HarvestHub.Services.Fields.Core.CultivationHistories.Repositories
{
    public interface ICultivationHistoryRepository
    {
        Task<CultivationHistory?> GetAsync(CultivationHistoryId historyId, CancellationToken cancellationToken);
        Task UpdateAsync(CultivationHistory cultivationHistory, CancellationToken cancellationToken);
        Task AddAsync(CultivationHistory cultivationHistory, CancellationToken cancellationToken);

    }
}
