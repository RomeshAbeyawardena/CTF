using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTF.Api.Migrations
{
    /// <inheritdoc />
    public partial class Added_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLog_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityLog_TransactionDefinition_TransactionDefinitionId",
                        column: x => x.TransactionDefinitionId,
                        principalTable: "TransactionDefinition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityLog_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityLog_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_GeneratedBySessionId",
                table: "Transaction",
                column: "GeneratedBySessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ParentTransactionId",
                table: "Transaction",
                column: "ParentTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ProcessedBySessionId",
                table: "Transaction",
                column: "ProcessedBySessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionDefinitionId",
                table: "Transaction",
                column: "TransactionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_OwnerTransactionId",
                table: "Session",
                column: "OwnerTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_SessionId",
                table: "ActivityLog",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_TransactionDefinitionId",
                table: "ActivityLog",
                column: "TransactionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_TransactionId",
                table: "ActivityLog",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_TransactionTypeId",
                table: "ActivityLog",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Transaction_OwnerTransactionId",
                table: "Session",
                column: "OwnerTransactionId",
                principalTable: "Transaction",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Session_GeneratedBySessionId",
                table: "Transaction",
                column: "GeneratedBySessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Session_ProcessedBySessionId",
                table: "Transaction",
                column: "ProcessedBySessionId",
                principalTable: "Session",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_TransactionDefinition_TransactionDefinitionId",
                table: "Transaction",
                column: "TransactionDefinitionId",
                principalTable: "TransactionDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_TransactionType_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId",
                principalTable: "TransactionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Transaction_ParentTransactionId",
                table: "Transaction",
                column: "ParentTransactionId",
                principalTable: "Transaction",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Transaction_OwnerTransactionId",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Session_GeneratedBySessionId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Session_ProcessedBySessionId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_TransactionDefinition_TransactionDefinitionId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_TransactionType_TransactionTypeId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Transaction_ParentTransactionId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_GeneratedBySessionId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ParentTransactionId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ProcessedBySessionId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_TransactionDefinitionId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Session_OwnerTransactionId",
                table: "Session");
        }
    }
}
