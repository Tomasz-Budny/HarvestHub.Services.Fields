using HarvestHub.Services.Fields.Core.Owners.Aggregates;
using HarvestHub.Services.Fields.Core.Owners.Repositories;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Repositories
{
    internal class OwnerRepository : IOwnerRepository
    {
        private readonly FieldsDbContext _dbContext;
        private readonly DbSet<Owner> _owners;

        public OwnerRepository(FieldsDbContext dbContext)
        {
            _dbContext = dbContext;
            _owners = dbContext.Owners;
        }
        public async Task<Owner?> GetAsync(OwnerId ownerId, CancellationToken cancellationToken)
         => await _owners
            .Where(x => x.Id == ownerId)
            .SingleOrDefaultAsync(cancellationToken);

        public async Task UpdateAsync(Owner field, CancellationToken cancellationToken)
        {
            _owners.Update(field);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddAsync(Owner owner, CancellationToken cancellationToken)
        {
            _dbContext.Add(owner);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
