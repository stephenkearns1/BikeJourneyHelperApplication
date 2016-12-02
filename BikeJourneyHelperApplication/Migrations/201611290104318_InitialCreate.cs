namespace BikeJourneyHelperApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BikeRepairShops",
                c => new
                    {
                        BikeRepairShopID = c.Int(nullable: false, identity: true),
                        ShopName = c.String(),
                        Address = c.String(),
                        OpeningHours = c.String(),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BikeRepairShopID);
            
            CreateTable(
                "dbo.DublinBikes",
                c => new
                    {
                        DublinBikeID = c.Int(nullable: false),
                        Location = c.String(),
                        Available = c.Int(nullable: false),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DublinBikeID);
            
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        GarageID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        OpeningHours = c.String(),
                        PumpsAvailable = c.String(),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.GarageID);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.NoteID);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        ShopID = c.Int(nullable: false, identity: true),
                        ShopName = c.String(),
                        Address = c.String(),
                        OpeningHours = c.String(),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ShopID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shops");
            DropTable("dbo.Notes");
            DropTable("dbo.Garages");
            DropTable("dbo.DublinBikes");
            DropTable("dbo.BikeRepairShops");
        }
    }
}
