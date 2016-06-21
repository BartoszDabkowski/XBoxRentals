namespace XBoxRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenresAndRatings : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT Genres ON
                INSERT INTO Genres(Id, Name) VALUES(1, 'Action')
                INSERT INTO Genres(Id, Name) VALUES(2, 'Adventure')
                INSERT INTO Genres(Id, Name) VALUES(3, 'Shooter')
                INSERT INTO Genres(Id, Name) VALUES(4, 'Role Playing')
                INSERT INTO Genres(Id, Name) VALUES(5, 'Survival Horror')
                SET IDENTITY_INSERT Genres OFF

                SET IDENTITY_INSERT Ratings ON
                INSERT INTO Ratings(Id, Name) VALUES(1, 'E')
                INSERT INTO Ratings(Id, Name) VALUES(2, 'T')
                INSERT INTO Ratings(Id, Name) VALUES(3, 'M')
                SET IDENTITY_INSERT Ratings OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
