using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTF.Api.Migrations
{
    /// <inheritdoc />
    public partial class Add_activity_types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [ActivityType] ([ID],[Name],[DisplayName],[Enabled]) " +
                "VALUES (NEWID(),'Unknown','Unknown', 1)");

            migrationBuilder.Sql("INSERT INTO [ActivityType] ([ID],[Name],[DisplayName],[Enabled]) " +
                "VALUES (NEWID(),'Insert','Insert data',1)");

            migrationBuilder.Sql("INSERT INTO [ActivityType] ([ID],[Name],[DisplayName],[Enabled]) " +
                "VALUES (NEWID(),'Update','Update data entry', 1)");

            migrationBuilder.Sql("INSERT INTO [ActivityType] ([ID],[Name],[DisplayName],[Enabled]) " +
                "VALUES (NEWID(),'Delete','Delete data entry', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [ActivityType] WHERE [Name] IN ('Unknown','Insert','Update','Delete')");
        }
    }
}
