using Microsoft.EntityFrameworkCore.Migrations;

namespace UserrManagementIdentity.Migrations
{
    public partial class seedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Security].[Users] ([Id], [FirstName], [LastName], [ProfilePic], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'69df017c-9eb0-400c-bff7-0376a38560bc', N'ahmed', N'zidan', NULL, N'20180025', N'20180025', N'20180025@stud.fci-cu.edu.eg', N'20180025@STUD.FCI-CU.EDU.EG', 1, N'AQAAAAEAACcQAAAAECKubB+bmyvk/lyJE4K86fk3HySZNM+GpgnKuNBBUTif4iIB4BCCUJ7UTeRmudZo6Q==', N'UTUHRSLYSVZ7OYYXNIBXAZJJVVFW5J3N', N'f0f6f0ee-3bf4-415b-a07e-847b6e73b70b', N'1115930826', 0, 0, NULL, 1, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [Security].[Users] where [Id] = N'69df017c-9eb0-400c-bff7-0376a38560bc'");

        }
    }
}
