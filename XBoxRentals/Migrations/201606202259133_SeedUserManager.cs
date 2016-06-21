namespace XBoxRentals.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUserManager : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b6d5953f-1517-43d3-be85-9704604c2e08', N'admin@domain.com', 0, N'AH3kVk0ZTaYKX0kI01KfFV1zTUVJmw30zd0o4QcLin+lqBtNpqEzn6ya1IToCogVNQ==', N'0f6d2475-b118-428c-a496-7ada78ef5b22', NULL, 0, 0, NULL, 1, 0, N'admin@domain.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'67ebf513-06b7-453a-bd19-0c3f44b03ee5', N'CanManageGames')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b6d5953f-1517-43d3-be85-9704604c2e08', N'67ebf513-06b7-453a-bd19-0c3f44b03ee5')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
