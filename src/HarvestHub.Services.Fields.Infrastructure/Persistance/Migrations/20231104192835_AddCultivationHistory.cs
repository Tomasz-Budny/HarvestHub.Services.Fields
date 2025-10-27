using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddCultivationHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "FieldId",
                schema: "fields",
                table: "CultivationHistory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_CultivationHistory_FieldId",
                schema: "fields",
                table: "CultivationHistory",
                column: "FieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CultivationHistory_FieldId",
                schema: "fields",
                table: "CultivationHistory");

            migrationBuilder.AlterColumn<Guid>(
                name: "FieldId",
                schema: "fields",
                table: "CultivationHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
