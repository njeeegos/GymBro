namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFacilityRatings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRatings",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Value = c.Int(nullable: false),
                    UserId = c.String(maxLength: 128),
                    RaterId = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.FacilityRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        SportsFacilityId = c.Int(nullable: false),
                        RaterId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SportsFacilities", t => t.SportsFacilityId, cascadeDelete: true)
                .Index(t => t.SportsFacilityId);
            
            AddColumn("dbo.Events", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Town", c => c.String());
            AddColumn("dbo.AspNetUsers", "AverageRating", c => c.Double(nullable: false));
            CreateIndex("dbo.Events", "ApplicationUser_Id");
            AddForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacilityRatings", "SportsFacilityId", "dbo.SportsFacilities");
            DropForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FacilityRatings", new[] { "SportsFacilityId" });
            DropIndex("dbo.UserRatings", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "AverageRating");
            DropColumn("dbo.AspNetUsers", "Town");
            DropColumn("dbo.Events", "ApplicationUser_Id");
            DropTable("dbo.FacilityRatings");
            DropTable("dbo.UserRatings");
        }
    }
}
