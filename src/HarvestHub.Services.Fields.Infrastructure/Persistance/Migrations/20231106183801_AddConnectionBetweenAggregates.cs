using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddConnectionBetweenAggregates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CultivationHistory",
                schema: "fields",
                table: "CultivationHistory");

            migrationBuilder.DropIndex(
                name: "IX_CultivationHistory_FieldId",
                schema: "fields",
                table: "CultivationHistory");

            migrationBuilder.RenameTable(
                name: "CultivationHistory",
                schema: "fields",
                newName: "HistoryRecords",
                newSchema: "fields");

            migrationBuilder.AddColumn<Guid>(
                name: "CultivationHistoryId",
                schema: "fields",
                table: "HistoryRecords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryRecords",
                schema: "fields",
                table: "HistoryRecords",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CultivationHistories",
                schema: "fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultivationHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CultivationHistories_Fields_FieldId",
                        column: x => x.FieldId,
                        principalSchema: "fields",
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryRecords_CultivationHistoryId",
                schema: "fields",
                table: "HistoryRecords",
                column: "CultivationHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CultivationHistories_FieldId",
                schema: "fields",
                table: "CultivationHistories",
                column: "FieldId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryRecords_CultivationHistories_CultivationHistoryId",
                schema: "fields",
                table: "HistoryRecords",
                column: "CultivationHistoryId",
                principalSchema: "fields",
                principalTable: "CultivationHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryRecords_CultivationHistories_CultivationHistoryId",
                schema: "fields",
                table: "HistoryRecords");

            migrationBuilder.DropTable(
                name: "CultivationHistories",
                schema: "fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryRecords",
                schema: "fields",
                table: "HistoryRecords");

            migrationBuilder.DropIndex(
                name: "IX_HistoryRecords_CultivationHistoryId",
                schema: "fields",
                table: "HistoryRecords");

            migrationBuilder.DropColumn(
                name: "CultivationHistoryId",
                schema: "fields",
                table: "HistoryRecords");

            migrationBuilder.RenameTable(
                name: "HistoryRecords",
                schema: "fields",
                newName: "CultivationHistory",
                newSchema: "fields");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CultivationHistory",
                schema: "fields",
                table: "CultivationHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CultivationHistory_FieldId",
                schema: "fields",
                table: "CultivationHistory",
                column: "FieldId");
        }
    }
}
