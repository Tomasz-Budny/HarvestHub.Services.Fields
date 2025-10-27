using HarvestHub.Services.Fields.Core.CultivationHistories.Aggregates;
using HarvestHub.Services.Fields.Core.CultivationHistories.Repositories;
using HarvestHub.Services.Fields.Core.CultivationHistories.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Repositories
{
    internal class CultivationHistoryRepository : ICultivationHistoryRepository
    {
        private readonly FieldsDbContext _dbContext;
        private readonly DbSet<CultivationHistory> _history;

        public CultivationHistoryRepository(FieldsDbContext dbContext)
        {
            _dbContext = dbContext;
            _history = dbContext.History;
        }
        public async Task<CultivationHistory?> GetAsync(CultivationHistoryId historyId, CancellationToken cancellationToken)
            => await _history
                .Include(x => x.History)
                .SingleOrDefaultAsync(x => x.Id == historyId, cancellationToken);

        public async Task UpdateAsync(CultivationHistory cultivationHistory, CancellationToken cancellationToken)
        {
            _history.Update(cultivationHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddAsync(CultivationHistory cultivationHistory, CancellationToken cancellationToken)
        {
            await _history.AddAsync(cultivationHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
