namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAndTime = c.DateTime(nullable: false),
                        MaxNumber = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        EventCreatorId = c.Int(nullable: false),
                        EventCreator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.EventCreator_Id)
                .ForeignKey("dbo.Sports", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.EventCreator_Id);
            
            AddColumn("dbo.AspNetUsers", "Event_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Event_Id");
            AddForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Sports");
            DropForeignKey("dbo.Events", "EventCreator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "EventCreator_Id" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropColumn("dbo.AspNetUsers", "Event_Id");
            DropTable("dbo.Events");
        }
    }
}
