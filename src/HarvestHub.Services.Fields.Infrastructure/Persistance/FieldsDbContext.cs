using HarvestHub.Services.Fields.Core.CultivationHistories.Aggregates;
using HarvestHub.Services.Fields.Core.Fields.Aggregates;
using HarvestHub.Services.Fields.Core.Owners.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance
{
    internal class FieldsDbContext : DbContext
    {
        public FieldsDbContext(DbContextOptions<FieldsDbContext> options) : base(options)
        {
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<CultivationHistory> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: "fields");

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
