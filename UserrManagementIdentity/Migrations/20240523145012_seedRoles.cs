using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UserrManagementIdentity.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[]
                {
                    "Id",
                    "Name",
                    "NormalizedName",
                    "ConcurrencyStamp"
                },
                values: new[]
                {
                    Guid.NewGuid().ToString(),
                    "Admin",
                    "Admin".ToLower(),
                    Guid.NewGuid().ToString()
                },
                schema: "Security"

                );

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[]
                {
                    "Id",
                    "Name",
                    "NormalizedName",
                    "ConcurrencyStamp"
                },
                values: new[]
                {
                    Guid.NewGuid().ToString(),
                    "User",
                    "User".ToLower(),
                    Guid.NewGuid().ToString()
                },
                schema: "Security"

                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [Security].[Roles]");
        }
    }
}
