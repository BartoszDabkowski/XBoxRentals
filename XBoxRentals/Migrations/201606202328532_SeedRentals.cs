namespace XBoxRentals.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedRentals : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Rentals] ON
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (1, N'2016-06-06 13:58:15', N'2016-06-06 14:03:56', 1, 1)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (2, N'2016-06-04 13:58:15', NULL, 4, 3)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (3, N'2016-06-03 13:58:15', NULL, 1, 5)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (4, N'2016-06-05 13:58:15', NULL, 3, 7)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (5, N'2016-06-02 13:58:15', N'2016-06-03 14:03:56', 4, 3)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (6, N'2016-06-01 13:58:15', NULL, 1, 3)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (7, N'2016-06-05 13:58:15', NULL, 3, 6)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (8, N'2016-06-06 13:58:15', N'2016-06-07 14:03:56', 4, 4)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (9, N'2016-06-01 13:58:15', NULL, 3, 7)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (10, N'2016-06-01 13:58:15', NULL, 6, 6)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (11, N'2016-06-01 13:58:15', N'2016-06-06 14:03:56', 4, 8)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (12, N'2016-06-04 13:58:15', NULL, 5, 4)
                INSERT INTO [dbo].[Rentals] ([Id], [DateRented], [DateReturned], [Customer_Id], [Game_Id]) VALUES (13, N'2016-06-06 13:58:15', NULL, 7, 6)
                SET IDENTITY_INSERT [dbo].[Rentals] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
