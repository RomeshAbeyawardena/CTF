using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTF.Api.Migrations
{
    /// <inheritdoc />
    public partial class Added_AuditedActivityTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_AuditedActivityTypeId",
                table: "ActivityLog",
                column: "AuditedActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_ActivityType_AuditedActivityTypeId",
                table: "ActivityLog",
                column: "AuditedActivityTypeId",
                principalTable: "ActivityType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_ActivityType_AuditedActivityTypeId",
                table: "ActivityLog");

            migrationBuilder.DropIndex(
                name: "IX_ActivityLog_AuditedActivityTypeId",
                table: "ActivityLog");
        }
    }
}
