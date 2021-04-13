namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaliSportSportsFacilitySami1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SportSportsFacilities", newName: "SportSportsFacility1");
            CreateTable(
                "dbo.SportSportsFacilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sport_Id = c.Int(nullable: false),
                        SportsFacility_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SportSportsFacilities");
            RenameTable(name: "dbo.SportSportsFacility1", newName: "SportSportsFacilities");
        }
    }
}
