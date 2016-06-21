namespace XBoxRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableGames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "NumberAvailable", c => c.Int(nullable: false));

            Sql("UPDATE Games SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "NumberAvailable");
        }
    }
}
