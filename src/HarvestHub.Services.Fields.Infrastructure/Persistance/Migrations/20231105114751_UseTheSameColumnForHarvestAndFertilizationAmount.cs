using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UseTheSameColumnForHarvestAndFertilizationAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FertilizationHistoryRecord_Amount",
                schema: "fields",
                table: "CultivationHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FertilizationHistoryRecord_Amount",
                schema: "fields",
                table: "CultivationHistory",
                type: "float",
                nullable: true);
        }
    }
}
