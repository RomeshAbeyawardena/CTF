using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTF.Api.Migrations
{
    /// <inheritdoc />
    public partial class Added_unique_indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransactionType_Name",
                table: "TransactionType");

            migrationBuilder.DropIndex(
                name: "IX_Resource_Name",
                table: "Resource");

            migrationBuilder.DropIndex(
                name: "IX_ActivityType_Name",
                table: "ActivityType");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionType_Name",
                table: "TransactionType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resource_Name",
                table: "Resource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityType_Name",
                table: "ActivityType",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransactionType_Name",
                table: "TransactionType");

            migrationBuilder.DropIndex(
                name: "IX_Resource_Name",
                table: "Resource");

            migrationBuilder.DropIndex(
                name: "IX_ActivityType_Name",
                table: "ActivityType");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionType_Name",
                table: "TransactionType",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_Name",
                table: "Resource",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityType_Name",
                table: "ActivityType",
                column: "Name");
        }
    }
}
