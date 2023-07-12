using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace CTF.Api.Migrations
{
    /// <inheritdoc />
    public partial class Add_features_to_ResourceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var namespaces = typeof(Instance).Assembly.GetTypes().Where(a => !string.IsNullOrWhiteSpace(a.Namespace)
                && a.Namespace.StartsWith("CTF.Features") && !a.Namespace.EndsWith("Models"))
                .Select(a => {
                    var n = a.Namespace!.Split('.');
                    return n[^1];
                }).OrderBy(a => a).Distinct().ToArray();

            var sqlBuilder = new StringBuilder("INSERT INTO [Resource] ([Id],[Name],[Description],[IsAvailable],[ImportedDate]) VALUES");
            bool isFirst = true;
            foreach (var @namespace in namespaces)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    sqlBuilder.Append(',');
                }

                sqlBuilder.AppendLine($"(NEWID(), '{@namespace}', '{@namespace} (Imported on {DateTimeOffset.UtcNow})', 1, GETUTCDATE())");
            }

            migrationBuilder.Sql(sqlBuilder.ToString());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Resource] WHERE [ImportedDate] IS NOT NULL");
        }
    }
}
