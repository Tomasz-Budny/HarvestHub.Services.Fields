using HarvestHub.Services.Fields.Core.Fields.Aggregates;
using HarvestHub.Services.Fields.Core.Fields.ValueObjects;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Configurations
{
    internal class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            ConfigureFieldsTable(builder);
            ConfigureVerticesTable(builder);
        }

        private void ConfigureFieldsTable(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("Fields");
            builder.HasIndex(x => new { x.Id, x.OwnerId }).IsUnique();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.OwnerId)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Name)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            var pointConverter = new ValueConverter<Point, string>(x => x.ToString(), x => Point.Create(x));
            builder.Property(x => x.Center)
                .IsRequired()
                .HasConversion(pointConverter);

            builder.Property(x => x.Area)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Area)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            var addressConverter = new ValueConverter<Address, string>(x => x.ToString(), x => Address.Create(x));
            builder.Property(x => x.Address)
                .IsRequired()
                .HasConversion(addressConverter);

            builder.Property(x => x.Color)
                .IsRequired()
                .HasMaxLength(7)
                .HasConversion(x => x.Value, x => new(x));
        }

        private void ConfigureVerticesTable(EntityTypeBuilder<Field> builder)
        {
            builder.OwnsMany(x => x.Vertices, vb =>
            {
                vb.ToTable("Vertices");
                vb.HasIndex("FieldId", "Id").IsUnique();
                vb.WithOwner().HasForeignKey("FieldId");

                vb.HasKey("Id");

                vb.Property<VertexId>("Id")
                    .IsRequired()
                    .HasConversion(x => x.Value, x => new(x));

                vb.Property<Order>("Order")
                    .IsRequired()
                    .HasConversion(x => x.Value, x => new(x));

                vb.Property<Latitude>("Latitude")
                    .IsRequired()
                    .HasConversion(x => x.Value, x => new(x));

                vb.Property<Longitude>("Longitude")
                    .IsRequired()
                    .HasConversion(x => x.Value, x => new(x));
            });

            builder.Metadata.FindNavigation(nameof(Field.Vertices))!
                    .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
