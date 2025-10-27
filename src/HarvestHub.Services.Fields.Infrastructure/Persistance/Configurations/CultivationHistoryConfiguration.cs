using HarvestHub.Services.Fields.Core.CultivationHistories.Aggregates;
using HarvestHub.Services.Fields.Core.Fields.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Configurations
{
    internal class CultivationHistoryConfiguration : IEntityTypeConfiguration<CultivationHistory>
    {
        public void Configure(EntityTypeBuilder<CultivationHistory> builder)
        {
            builder.ToTable("CultivationHistories");

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.FieldId)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.HasMany(x => x.History).WithOne().HasForeignKey("CultivationHistoryId").OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Field>().WithOne().HasForeignKey<CultivationHistory>(x => x.FieldId);
        }
    }
}