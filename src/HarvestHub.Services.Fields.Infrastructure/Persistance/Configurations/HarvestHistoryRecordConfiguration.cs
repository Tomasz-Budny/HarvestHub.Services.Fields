using HarvestHub.Services.Fields.Core.CultivationHistories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Configurations
{
    internal class HarvestHistoryRecordConfiguration : IEntityTypeConfiguration<HarvestHistoryRecord>
    {
        public void Configure(EntityTypeBuilder<HarvestHistoryRecord> builder)
        {
            builder.Property(x => x.Amount)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x))
                .HasColumnName("Amount");

            builder.Property(x => x.Humidity)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.CropType)
                .IsRequired();
        }
    }
}
