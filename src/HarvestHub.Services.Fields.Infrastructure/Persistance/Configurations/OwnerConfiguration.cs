using HarvestHub.Services.Fields.Core.Owners.Aggregates;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Configurations
{
    internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners");
            builder.HasIndex(x => new { x.Id }).IsUnique();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            var pointConverter = new ValueConverter<Point?, string>(x => x.ToString(), x => Point.Create(x));
            builder.Property(x => x.StartLocation)
                .HasConversion(pointConverter);

            var addressConverter = new ValueConverter<Address?, string>(x => x.ToString(), x => Address.Create(x));
            builder.Property(x => x.Address)
                .HasConversion(addressConverter);

            builder.Property(x => x.NumberOfFields)
                .IsRequired();

            builder.Property(x => x.SumArea)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));
        }
    }
}
