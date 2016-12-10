namespace BikeJourneyHelperApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAvailBikes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DublinBikes", "Available");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DublinBikes", "Available", c => c.Int(nullable: false));
        }
    }
}
