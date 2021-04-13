namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SrediliSmoModele : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "SportId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sports", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SportsFacilities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SportsFacilities", "Address", c => c.String(nullable: false));
            CreateIndex("dbo.Events", "SportId");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Sports");
            AddForeignKey("dbo.Events", "SportId", "dbo.Sports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "LocationId", "dbo.SportsFacilities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "LocationId", "dbo.SportsFacilities");
            DropForeignKey("dbo.Events", "SportId", "dbo.Sports");
            DropIndex("dbo.Events", new[] { "SportId" });
            AlterColumn("dbo.SportsFacilities", "Address", c => c.String());
            AlterColumn("dbo.SportsFacilities", "Name", c => c.String());
            AlterColumn("dbo.Sports", "Name", c => c.String());
            DropColumn("dbo.Events", "SportId");
        }
    }
}
