namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brisemoVisakTabelu : DbMigration
    {
        public override void Up()
        {
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
        }
        
        public override void Down()
        {
            DropTable("SportSportsFacility1");

        }
    }
}
