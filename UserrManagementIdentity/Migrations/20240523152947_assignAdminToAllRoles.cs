using Microsoft.EntityFrameworkCore.Migrations;

namespace UserrManagementIdentity.Migrations
{
    public partial class assignAdminToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Security].[userRoles]([UserId],[RoleId])select N'69df017c-9eb0-400c-bff7-0376a38560bc' , id from Security.Roles");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [Security].[userRoles] where [UserId] =  N'69df017c-9eb0-400c-bff7-0376a38560bc'");

        }
    }
}
