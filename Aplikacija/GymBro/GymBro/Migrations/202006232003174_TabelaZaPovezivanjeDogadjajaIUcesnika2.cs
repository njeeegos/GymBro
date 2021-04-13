namespace GymBro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaZaPovezivanjeDogadjajaIUcesnika2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventParticipants", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventParticipants", "UserId", c => c.Int(nullable: false));
        }
    }
}
