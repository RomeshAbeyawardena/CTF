using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTF.Api.Migrations
{
    /// <inheritdoc />
    public partial class Added_clientex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "TransactionDefinition",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Session",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Resource",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Policy",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "ActivityLog",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDefinition_ClientId",
                table: "TransactionDefinition",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ClientId",
                table: "Transaction",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_ClientId",
                table: "Session",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ClientId",
                table: "Resource",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_ClientId",
                table: "ActivityLog",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_Client_ClientId",
                table: "ActivityLog",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Client_ClientId",
                table: "Resource",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Client_ClientId",
                table: "Session",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Client_ClientId",
                table: "Transaction",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDefinition_Client_ClientId",
                table: "TransactionDefinition",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_Client_ClientId",
                table: "ActivityLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Client_ClientId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Client_ClientId",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Client_ClientId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDefinition_Client_ClientId",
                table: "TransactionDefinition");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDefinition_ClientId",
                table: "TransactionDefinition");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ClientId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Session_ClientId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Resource_ClientId",
                table: "Resource");

            migrationBuilder.DropIndex(
                name: "IX_ActivityLog_ClientId",
                table: "ActivityLog");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "TransactionDefinition");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ActivityLog");
        }
    }
}
