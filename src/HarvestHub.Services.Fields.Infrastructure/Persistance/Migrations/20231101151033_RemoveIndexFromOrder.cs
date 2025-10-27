using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIndexFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vertices_FieldId_Order",
                schema: "fields",
                table: "Vertices");

            migrationBuilder.CreateIndex(
                name: "IX_Vertices_FieldId_Id",
                schema: "fields",
                table: "Vertices",
                columns: new[] { "FieldId", "Id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vertices_FieldId_Id",
                schema: "fields",
                table: "Vertices");

            migrationBuilder.CreateIndex(
                name: "IX_Vertices_FieldId_Order",
                schema: "fields",
                table: "Vertices",
                columns: new[] { "FieldId", "Order" },
                unique: true);
        }
    }
}
