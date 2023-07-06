using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTF.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    DisplayName = table.Column<string>(type: "NVARCHAR(2000)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDefinition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Token = table.Column<string>(type: "NVARCHAR(800)", nullable: false),
                    Subject = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Payload = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    ValidFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ValidTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(80)", nullable: false),
                    DisplayName = table.Column<string>(type: "NVARCHAR(2000)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLog_ActivityType_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityType",
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
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Key = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Token = table.Column<string>(type: "NVARCHAR(800)", nullable: false),
                    Subject = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    ValidFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ValidTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GeneratedBySessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessedBySessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Payload = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Hash = table.Column<string>(type: "NVARCHAR(2000)", nullable: false),
                    ValidFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ProcessedTimestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Session_GeneratedBySessionId",
                        column: x => x.GeneratedBySessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Session_ProcessedBySessionId",
                        column: x => x.ProcessedBySessionId,
                        principalTable: "Session",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionDefinition_TransactionDefinitionId",
                        column: x => x.TransactionDefinitionId,
                        principalTable: "TransactionDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Transaction_ParentTransactionId",
                        column: x => x.ParentTransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_ActivityTypeId",
                table: "ActivityLog",
                column: "ActivityTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Session_OwnerTransactionId",
                table: "Session",
                column: "OwnerTransactionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_Session_SessionId",
                table: "ActivityLog",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_Transaction_TransactionId",
                table: "ActivityLog",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Transaction_OwnerTransactionId",
                table: "Session",
                column: "OwnerTransactionId",
                principalTable: "Transaction",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Session_GeneratedBySessionId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Session_ProcessedBySessionId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "TransactionDefinition");

            migrationBuilder.DropTable(
                name: "TransactionType");
        }
    }
}
