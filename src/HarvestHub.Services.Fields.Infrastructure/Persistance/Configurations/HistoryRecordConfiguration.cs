using HarvestHub.Services.Fields.Core.CultivationHistories.Entities;
using HarvestHub.Services.Fields.Core.CultivationHistories.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Configurations
{
    internal class HistoryRecordConfiguration : IEntityTypeConfiguration<HistoryRecord>
    {
        public void Configure(EntityTypeBuilder<HistoryRecord> builder)
        {
            builder.ToTable("HistoryRecords");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property<CultivationHistoryId>("CultivationHistoryId")
                .HasConversion(x => x.Value, x => new(x))
                .HasColumnName("CultivationHistoryId");

            builder
                .HasDiscriminator<string>("Type")
                .HasValue<HarvestHistoryRecord>("harvest")
                .HasValue<FertilizationHistoryRecord>("fertilization");
        }
    }
}
