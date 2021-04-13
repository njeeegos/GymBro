namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaliModelZaSlikeSportskihObjekata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacilityImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                        SportsFacilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FacilityImages");
        }
    }
}
