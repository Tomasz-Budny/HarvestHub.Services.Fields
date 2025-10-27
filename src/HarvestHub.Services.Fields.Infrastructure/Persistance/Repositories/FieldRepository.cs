using HarvestHub.Services.Fields.Core.Fields.Aggregates;
using HarvestHub.Services.Fields.Core.Fields.Entities;
using HarvestHub.Services.Fields.Core.Fields.Repositories;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Repositories
{
    internal class FieldRepository : IFieldRepository
    {
        private readonly FieldsDbContext _dbContext;
        private readonly DbSet<Field> _fields;

        public FieldRepository(FieldsDbContext dbContext)
        {
            _dbContext = dbContext;
            _fields = dbContext.Fields;
        }

        public async Task AddAsync(Field field, CancellationToken cancellationToken)
        {
            await _fields.AddAsync(field);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Field field, CancellationToken cancellationToken)
        {
            _fields.Remove(field);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Field field, CancellationToken cancellationToken)
        {
            _fields.Update(field);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Field?> GetAsync(FieldId fieldId, OwnerId ownerId, CancellationToken cancellationToken)
            => await _fields
             .Include(x => x.Vertices.OrderBy(x => x.Order))
             .Where(x => x.Id == fieldId && x.OwnerId == ownerId)
             .SingleOrDefaultAsync(cancellationToken);

    }
}
