namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaliListuUSport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sports", "SportsFacility_Id", "dbo.SportsFacilities");
            DropIndex("dbo.Sports", new[] { "SportsFacility_Id" });
            CreateTable(
                "dbo.SportSportsFacility1",
                c => new
                    {
                        Sport_Id = c.Int(nullable: false),
                        SportsFacility_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sport_Id, t.SportsFacility_Id })
                .ForeignKey("dbo.Sports", t => t.Sport_Id, cascadeDelete: true)
                .ForeignKey("dbo.SportsFacilities", t => t.SportsFacility_Id, cascadeDelete: true)
                .Index(t => t.Sport_Id)
                .Index(t => t.SportsFacility_Id);
            
            DropColumn("dbo.Sports", "SportsFacility_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sports", "SportsFacility_Id", c => c.Int());
            DropForeignKey("dbo.SportSportsFacility1", "SportsFacility_Id", "dbo.SportsFacilities");
            DropForeignKey("dbo.SportSportsFacility1", "Sport_Id", "dbo.Sports");
            DropIndex("dbo.SportSportsFacility1", new[] { "SportsFacility_Id" });
            DropIndex("dbo.SportSportsFacility1", new[] { "Sport_Id" });
            DropTable("dbo.SportSportsFacility1");
            CreateIndex("dbo.Sports", "SportsFacility_Id");
            AddForeignKey("dbo.Sports", "SportsFacility_Id", "dbo.SportsFacilities", "Id");
        }
    }
}
