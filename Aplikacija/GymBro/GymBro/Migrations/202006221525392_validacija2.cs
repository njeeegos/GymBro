namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validacija2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "EventCreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "EventCreatorId" });
            AlterColumn("dbo.Events", "EventCreatorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "EventCreatorId");
            AddForeignKey("dbo.Events", "EventCreatorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventCreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "EventCreatorId" });
            AlterColumn("dbo.Events", "EventCreatorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Events", "EventCreatorId");
            AddForeignKey("dbo.Events", "EventCreatorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
