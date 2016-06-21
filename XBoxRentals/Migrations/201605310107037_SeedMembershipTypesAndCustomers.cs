namespace XBoxRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedMembershipTypesAndCustomers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    BirthDate = c.DateTime(nullable: false),
                    IsSubscribedToEmail = c.Boolean(nullable: false),
                    MembershipTypeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);

            CreateTable(
                "dbo.MembershipTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    SignUpFee = c.Short(nullable: false),
                    DurationInMonths = c.Byte(nullable: false),
                    DiscountRate = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            Sql(@"
                SET IDENTITY_INSERT MembershipTypes ON
                INSERT INTO MembershipTypes(Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 'Pay as you go', 0, 0, 0)
                INSERT INTO MembershipTypes(Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 'Monthly', 30, 1, 10)
                INSERT INTO MembershipTypes(Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 'Quarterly', 90, 3, 15)
                INSERT INTO MembershipTypes(Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 'Annually', 300, 12, 20)
                SET IDENTITY_INSERT MembershipTypes OFF

                SET IDENTITY_INSERT Customers ON
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (1, 'John Smith', '10/12/1983', 1, 1)
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (2, 'Rohan Kapoor', '01/30/1975', 0, 1)
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (3, 'Sally Jackson', '05/22/1992', 1, 3)
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (4, 'Maria Hernandez', '04/04/1990', 0, 4)
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (5, 'Derrick Washington', '12/22/1955', 0, 2)
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (6, 'Devon Jefferson', '05/17/1989', 1, 2)
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (7, 'Frank Whitman', '07/13/1968', 0, 3)
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (8, 'Justin Lee', '03/24/1999', 0, 4)
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (9, 'Bob Johnson', '06/05/1987', 1, 2)
                INSERT INTO Customers(Id, Name, BirthDate, IsSubscribedToEmail, MembershipTypeId) VALUES (10, 'Jasmine Zare', '11/09/1988', 0, 1)
                SET IDENTITY_INSERT Customers OFF
            ");


        }

        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] {"MembershipTypeId"});
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}


