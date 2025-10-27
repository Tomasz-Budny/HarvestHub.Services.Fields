using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addHistoryEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CultivationHistory",
                schema: "fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FertilizerType = table.Column<int>(type: "int", nullable: true),
                    FertilizationHistoryRecord_Amount = table.Column<double>(type: "float", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    CropType = table.Column<int>(type: "int", nullable: true),
                    Humidity = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultivationHistory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CultivationHistory",
                schema: "fields");
        }
    }
}
