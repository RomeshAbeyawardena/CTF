using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTF.Api.Migrations
{
    /// <inheritdoc />
    public partial class Added_Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Reference = table.Column<string>(type: "NVARCHAR(80)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    DisplayName = table.Column<string>(type: "NVARCHAR(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Client_ParentClientId",
                        column: x => x.ParentClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Name",
                table: "Client",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_ParentClientId",
                table: "Client",
                column: "ParentClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Reference",
                table: "Client",
                column: "Reference",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
