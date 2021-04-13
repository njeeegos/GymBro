namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaZaPovezivanjeDogadjajaIUcesnika : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventParticipants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventParticipants");
        }
    }
}
