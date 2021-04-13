namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mape : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SportsFacilities", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.SportsFacilities", "Latitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SportsFacilities", "Latitude");
            DropColumn("dbo.SportsFacilities", "Longitude");
        }
    }
}
